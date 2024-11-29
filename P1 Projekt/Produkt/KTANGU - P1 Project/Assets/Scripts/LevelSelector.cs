using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public void LevelOne()
    {
        SceneManager.LoadScene(2);
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene(3);
    }

    public void LevelThree()
    {
        SceneManager.LoadScene(4);
    }
}
