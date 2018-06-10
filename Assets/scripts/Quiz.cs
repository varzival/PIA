using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour {

    public float time;
    public Text timer;
    public Text quizText;
    public Text quizCaption;
    public Button[] buttons;
    public Color correctColor;
    public Color wrongColor;
    public QuizData quizData;
    public string nextScene;
    
    private int correctButton;
    private float timeSpent = 0.0f;
    private int currentQuestion = 0;
    private float waitChangeTime = 2.0f;
    private bool interactable = true;


    // Use this for initialization
    void Start () {

        StationData.stations[quizData.station].discovered = true;
        PersistantSaver.saveDiscoveredStations();
        
        currentQuestion = PersistantSaver.getCurrentQuestion() + 1;
        if (currentQuestion > quizData.questions.Length)
        {
            PersistantSaver.setCurrentQuestion(-1);
            SceneManager.LoadScene(nextScene);
        }

        else
        {
            timer.text = time.ToString("F0");

            FillQuiz(quizData.questions[currentQuestion]);
        }

        PersistantSaver.saveToHardDrive();
        //delegateButtons();
    }

    /*
    void delegateButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            if (i == correctButton) buttons[i].onClick.AddListener(delegate { CorrectClicked(i); });
            else
            {
                Debug.Log("Current i: " + i);
                buttons[i].onClick.AddListener(delegate { InCorrectClicked(i); });
            }

        }
    }
    */

    void FillQuiz(QuizData.Question question)
    {
        interactable = true;
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
        //delegateButtons();
    }
	
	// Update is called once per frame
	void Update () {
        timeSpent += Time.deltaTime;
        if (timeSpent > time)
        {
            timeSpent = time;
        }
        timer.text = (time - timeSpent).ToString("F0");
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
        PersistantSaver.incrementPoints(quizData.station);
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

        if (currentQuestion >= quizData.questions.Length)
        {
            PersistantSaver.setCurrentQuestion(-1);
            PersistantSaver.setCurrentScene(nextScene);
            yield return new WaitForSeconds(waitChangeTime);
            SceneManager.LoadScene(nextScene);
        }

        else
        {
            PersistantSaver.setCurrentQuestion(currentQuestion);
            yield return new WaitForSeconds(waitChangeTime);
            timeSpent = 0.0f;
            foreach(Button but in buttons)
            {
                but.gameObject.GetComponent<Image>().color = Color.white;
            }

            FillQuiz(quizData.questions[currentQuestion]);
            interactable = true;
            

        }

        
    }
}
