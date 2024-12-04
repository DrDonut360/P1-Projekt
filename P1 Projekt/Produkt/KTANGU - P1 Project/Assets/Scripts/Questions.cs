using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    private List<string> questions = new List<string>
    {
        "If I make mistakes in teams, it is often held against me.",
        "I have always been able to bring up problems and tough issues in teamwork.",
        "I've noticed that people in teams sometimes reject others for being different.",
        "It is safe to take a risk on the teams I've worked with.",
        "It is difficult to ask other team members for help.",
        "No one, on teams I've worked with, would deliberately act in a way that undermined my efforts.",
        "Working in teamwork, my unique skills and talents are often valued and utilized.",
        "In my previous teams, we actively sought out each other for constructive discussions.",
        "In my previous teams, we were encouraged to try new ways of doing things.",
        "In my previous teams, we were comfortable with exploring unfamiliar or unknown ideas and perspectives.",
        "Building on each other's ideas has been an integral part of how teams I've worked with operate.",
        "In my previous teams, behaviors conducive to a trustful environment were actively promoted."
    };

    public string GetRandomQuestion()
    {
        int randomIndex = UnityEngine.Random.Range(0, questions.Count);
        string question = questions[randomIndex];

        questions.RemoveAt(randomIndex);

        Debug.Log(question);
        return question;
    }
}
