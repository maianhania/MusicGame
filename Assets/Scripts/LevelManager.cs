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

    public void PlayAgain()
    {
        SceneManager.LoadScene(lastLevel);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
