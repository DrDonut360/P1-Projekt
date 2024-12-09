using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class QuizManager : MonoBehaviour
{
    [SerializeField] GameObject popupPanel;
    [SerializeField] Text text;
    [SerializeField] Questions questions;

    private float timer;
    
    public bool showingQuiz = false;
    void WriteQuestion()
    {
        text.text = questions.GetRandomQuestion();
    }

    void Update()
    {
        if (showingQuiz)
        {
            timer -= Time.deltaTime;
            if (Input.anyKeyDown && timer < 0)
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
        timer = 2;  // 2 sec timer before able to hide question. Prevents misclick
    }

    // Hide the popup
    public void HideQuiz()
    {
        popupPanel.SetActive(false);
        showingQuiz = false;
    }
}