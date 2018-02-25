using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{

    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject music;
    private AudioSource actualMusic;

    private void Start()
    {
        gameIsPaused = false;
        actualMusic = music.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        //HandleClick();
    }

    public void HandleClick()
    {
        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }

    }

    public void Pause()
    {
        //pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        actualMusic.Pause();
        gameIsPaused = true;
    }

    public void Resume()
    {
        //pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        actualMusic.UnPause();
        gameIsPaused = false;
    }
}
