using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizData : MonoBehaviour {

    public int station;

    [System.Serializable]
    public class Question
    {
        public string quizText;
        public string correctText;
        public string[] wrongTexts = new string[3];
    }

    public Question[] questions;

	void Awake()
    {

    }

}
