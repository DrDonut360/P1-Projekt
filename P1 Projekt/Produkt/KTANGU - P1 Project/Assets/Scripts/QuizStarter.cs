using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class QuizStarter : Collectable
{
    
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("start quiz");
            FindObjectOfType<QuizManager>().ShowQuiz();
            Destroy(gameObject);
        }
    }
}
