using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSelector : MonoBehaviour
{

    //// Start is called before the first frame update
    //void Start()
    //{
    //}

    //// Update is called once per frame
    //void Update()
    //{
        

    //}

    //hav et dictionary med scener, led efter scener. tjeck hvilken scene vi er på.
    //Tjekker om playeren går ind i vores mål, hvis den gør dette vll den gå til en ny scene.
    void OnCollisionEnter2D(Collision2D other)
    {
        //Make a method for finding a scene name... and stuff
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;
        Debug.Log($"the name of the scene is : {sceneName}");


        if (other.gameObject.CompareTag("Player") && sceneName == "Start-End")
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
            SceneManager.LoadScene("LeveltThree");
        }
        else if (other.gameObject.CompareTag("Player") && sceneName == "LevelThree")
        {
            Debug.Log("Loading Main Menu");
            SceneManager.LoadScene("MainMenu");
        }
    }

    


}
