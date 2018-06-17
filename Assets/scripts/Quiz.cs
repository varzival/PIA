using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour {

    public int timeInSeconds;
    public Text timer;
    public Text quizText;
    public Text quizCaption;
    public Button[] buttons;
    public Color correctColor;
    public Color wrongColor;
    public string nextScene;
    
    private int correctButton;
    private System.DateTime startTime;
    private int currentQuestion = 0;
    private float waitChangeTime = 2.0f;
    private bool interactable = true;
    private int station;


    // Use this for initialization
    void Start () {

        station = PersistantSaver.getCurrentStation();

        PersistantSaver.playerData.stationStats[station].discovered = true;
        
        currentQuestion = PersistantSaver.playerData.currentQuestion + 1;
        if (currentQuestion > StationData.stations[station].quizQuestions.Length)
        {
            PersistantSaver.playerData.currentQuestion = -1;
            SceneManager.LoadScene(nextScene);
        }

        else
        {
            startTime = System.DateTime.Now;
            timer.text = timeInSeconds+"";

            FillQuiz(StationData.stations[station].quizQuestions[currentQuestion]);
        }

        PersistantSaver.saveToHardDrive();
    }

    void FillQuiz(StationData.Question question)
    {
        quizText.text = question.quizText;
        quizCaption.text = "Frage " + (currentQuestion + 1);
        correctButton = 0;
        //Shuffle Buttons
        for (int i = buttons.Length-1; i>0; i--)
        {
            int j = Random.Range(0, i + 1);
            Button tmp = buttons[i];
            buttons[i] = buttons[j];
            buttons[j] = tmp;
        }
        buttons[correctButton].GetComponentInChildren<Text>().text = question.correctText;
        for (int i = 0; i<3; i++)
        {
            buttons[i+1].GetComponentInChildren<Text>().text = question.wrongTexts[i];
        }

    }
	
	// Update is called once per frame
	void Update () {

        if (interactable)
        {
            System.DateTime now = System.DateTime.Now;
            System.TimeSpan diff = now - startTime;

            if (diff.Seconds > timeInSeconds)
            {
                timer.text = "0";
                StartCoroutine(correctButtonBlink());
                StartCoroutine(ChangeQuestion());
            }
            else
            {
                timer.text = timeInSeconds - diff.Seconds + "";
            }
        }
        
    }

    public void onButtonClick(Button but)
    {
        if (!interactable) return;
        for (int i = 0; i<buttons.Length; i++)
        {
            if (but == buttons[i])
            {
                if (i == correctButton) CorrectClicked(i);
                else InCorrectClicked(i);
                break;
            }
        }
    }

    void CorrectClicked(int buttonNr)
    {
        buttons[correctButton].gameObject.GetComponent<Image>().color = correctColor;
        PersistantSaver.incrementPoints(station);
        StartCoroutine(ChangeQuestion());
    }

    void InCorrectClicked(int buttonNr)
    {
        buttons[buttonNr].gameObject.GetComponent<Image>().color = wrongColor;
        StartCoroutine(correctButtonBlink());
        StartCoroutine(ChangeQuestion());
    }

    IEnumerator correctButtonBlink()
    {
        int blinks = 4;
        float highlightTime = waitChangeTime / (blinks * 2.0f);
        for (int i = 0; i<blinks; i++)
        {
            buttons[correctButton].gameObject.GetComponent<Image>().color = correctColor;
            yield return new WaitForSeconds(highlightTime);
            buttons[correctButton].gameObject.GetComponent<Image>().color = Color.white;
            yield return new WaitForSeconds(highlightTime);
        }
    }

    IEnumerator ChangeQuestion()
    {
        interactable = false;

        currentQuestion++;

        if (currentQuestion >= StationData.stations[station].quizQuestions.Length)
        {
            PersistantSaver.playerData.currentQuestion = -1;
            PersistantSaver.playerData.currentScene = nextScene;
            PersistantSaver.saveToHardDrive();
            yield return new WaitForSeconds(waitChangeTime);
            SceneManager.LoadScene(nextScene);
        }

        else
        {
            PersistantSaver.playerData.currentQuestion = currentQuestion;
            PersistantSaver.saveToHardDrive();
            yield return new WaitForSeconds(waitChangeTime);
            
            foreach(Button but in buttons)
            {
                but.gameObject.GetComponent<Image>().color = Color.white;
            }

            FillQuiz(StationData.stations[station].quizQuestions[currentQuestion]);
            interactable = true;
            startTime = System.DateTime.Now;

        }

        
    }
}
