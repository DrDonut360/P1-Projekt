using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questions : MonoBehaviour
{
    private string[] questions = 
    {
        "If you make a mistake on this team, it is often held against you.",
        "Members of this team are able to bring up problems and tough issues.",
        "People on this team sometimes reject others for being different.",
        "It is safe to take a risk on this team.",
        "It is difficult to ask other members of this team for help.",
        "No one on this team would deliberately act in a way that undermines my efforts.",
        "Working with members of this team, my unique skills and talents are valued and utilized.",
        "In our team we actively seek out each other for constructive discussions.",
        "In our team we are encouraged to try new ways of doing things.",
        "In our team we are comfortable with exploring unfamiliar or unknown ideas and perspectives.",
        "Building on each other's ideas is an integral part of how we work in our team.",
        "In our team we promote behaviors that are conducive towards a trustful environment.",
        //"I feel confident I can perform well in my study.",
        "I found teamwork beneficial for my learning.",
        //"I am satisfied with the support provided by the university during my study.",
        //"In general, I feel happy about my study."
    };

    public string GetRandomQuestion()
    {
        int randomIndex = UnityEngine.Random.Range(0, questions.Length);
        Debug.Log(questions[randomIndex]);
        return questions[randomIndex];
    }
}
