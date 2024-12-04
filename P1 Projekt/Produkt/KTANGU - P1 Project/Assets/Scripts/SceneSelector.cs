using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class SceneSelector : MonoBehaviour
{
    //YOU NEED TO add a transition animator to each instance of the mainGoal Prefab. (do this ony when you need to add a new one now)
    //You do this by adding another inspector view, locking one on the canvas UI element and the other go to the main goal.
    //Then add the animator component of the canvas to the public animator value of the SceneSelector script
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

        // this checks if the player is in the scene start end, if so redirected to the level scenes.
        // then starts the whole process of loading the correct levels calling the method LoadNextLevel with no start peramiters
        if (other.gameObject.CompareTag("Player") && sceneName == "Start-End")
        {
            Debug.Log("Loading 1st level");
            SceneManager.LoadScene("LevelOne");

        }
        else if (other.gameObject.CompareTag("Player"))
        {
            LoadNextLevel();
        }

    }

    //we make a method that starts the corutine, we do not need to end this manually since the change of scene stops it automatically.
    
    public void LoadNextLevel()
    {
        Debug.Log($"Loading {SceneManager.GetActiveScene().name}");

        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));

        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // the corutine controls the scene change by starting the transition animation, waiting untill it is over,
    // then changing the scene based on the start peramiter, which is the current build index +1, this is the next level.

    //IT IS VITALLY IMPORTANT THAT THE LEVEL SCENES COME FIRST IN THE BUILD ORDER!
    //from first at the top, to the last level last. All the other scenes such as menu scenes and so on, does not rely on the build index,
    //thus is placed last in the build index.
    IEnumerator LoadLevel(int LevelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(TransAnimTime);

        SceneManager.LoadScene(LevelIndex);
    }



}
