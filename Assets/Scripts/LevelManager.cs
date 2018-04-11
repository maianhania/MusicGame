using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public static string lastLevel;

    public void LoadLevel(string name)
    {
        lastLevel = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(name);
        
    }

    public void LoadLevelWithDelay(string name)
    {
        StartCoroutine(LoadDelay(name));

    }

    private IEnumerator LoadDelay(string name)
    {
        lastLevel = SceneManager.GetActiveScene().name;
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(name);
    }

    public void LoadLastLevel()
    {
        SceneManager.LoadScene(lastLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
