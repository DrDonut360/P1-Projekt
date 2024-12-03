using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class SceneSelector : MonoBehaviour
{
    
    public Animator transition;
    public float TransAnimTime = 1f;

    //hav et dictionary med scener, led efter scener. tjeck hvilken scene vi er p�.
    //Tjekker om playeren g�r ind i vores m�l, hvis den g�r dette vll den g� til en ny scene.
    void OnCollisionEnter2D(Collision2D other)
    {
        //Make a method for finding a scene name... and stuff
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        //int currentLvlIndex = SceneManager.GetActiveScene().buildIndex + 1;
        Debug.Log($"the name of the scene is : {sceneName}");


        if (other.gameObject.CompareTag("Player") && sceneName == "Start-End")
        {
            Debug.Log("Loading 1st level");
            SceneManager.LoadScene("LevelOne");

        }
        else if (other.gameObject.CompareTag("Player"))
        {
            LoadNextLevel();
        }
        

        

        /*if (other.gameObject.CompareTag("Player") && sceneName == "Start-End")
        {
            Debug.Log("Loading 1st level");
            SceneManager.LoadScene("LevelOne");

        }
        else if (other.gameObject.CompareTag("Player") && sceneName == "LevelOne")
        {
            Debug.Log("Loading 2nd level");
            SceneManager.LoadScene("LevelTwo");
        }
        else if (other.gameObject.CompareTag("Player") && sceneName == "LevelTwo")
        {
            Debug.Log("Loading 3rd level");
            SceneManager.LoadScene("LevelThree");
        }
        else if (other.gameObject.CompareTag("Player") && sceneName == "LevelThree")
        {
            Debug.Log("Loading Main Menu");
            SceneManager.LoadScene("MainMenu");
        }*/
    }
    public void LoadNextLevel ()
    {
        Debug.Log($"Loading {SceneManager.GetActiveScene().name}");

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator LoadLevel (int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransAnimTime);

        SceneManager.LoadScene(LevelIndex);
    }



}
