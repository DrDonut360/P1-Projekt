using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    [SerializeField] GameObject popupPanel;
    [SerializeField] Text text;
    [SerializeField] Questions questions;
    
    private bool showingQuiz = false;
    void WriteQuestion()
    {
        text.text = questions.GetRandomQuestion();
    }

    void Update()
    {
        if (showingQuiz)
        {
            if (Input.anyKeyDown)
            {
                HideQuiz();
            }
        }
    }
    public void ShowQuiz()
    {
        WriteQuestion();
        popupPanel.SetActive(true);
        showingQuiz = true;
    }

    // Hide the popup
    public void HideQuiz()
    {
        popupPanel.SetActive(false);
        showingQuiz = false;
    }
}