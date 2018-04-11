using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public GameObject rect;
    public GameObject bgPanel;
    public GameObject optionsPanel;
    public static bool gameIsPaused;
    public GameObject music;
    private AudioSource actualMusic;
    public GameObject scrollView;
    public bool isMatchingGame;
    public bool lastMusicState; // whether music was on before
    public bool isInstructions;

    private void Start()
    {
        if (!isInstructions)
        {
            actualMusic = music.GetComponent<AudioSource>();
        }

    }

    // Update is called once per frame
    void Update()
    {
        HideIfClickedOutside();
    }


    private void HideIfClickedOutside()
    {
        if (Input.GetMouseButton(0) && rect.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                rect.GetComponent<RectTransform>(),
                Input.mousePosition,
                null))
        {
            rect.SetActive(false);
            bgPanel.SetActive(false);
            optionsPanel.SetActive(false);
            Resume();
        }
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
        //lastMusicState = actualMusic.isPlaying;
        //Debug.Log("Entering settings panel with game being paused? " + !lastMusicState);
        //pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        actualMusic.Pause();
        //gameIsPaused = actualMusic.isPlaying; // true
        if (isMatchingGame && scrollView.activeSelf)
        {
            scrollView.SetActive(false);
        }
    }

    public void Resume()
    {
       
        Time.timeScale = 1f;
        actualMusic.UnPause();
        //pauseMenuUI.SetActive(false);
        //if (lastMusicState)
        //{
        //    Time.timeScale = 1f;
        //    actualMusic.UnPause();
        //    //gameIsPaused = actualMusic.isPlaying; // false
        //}

        

        if (isMatchingGame && !scrollView.activeSelf)
        {
            scrollView.SetActive(true);
        }
    }
}
