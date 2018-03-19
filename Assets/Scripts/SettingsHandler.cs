using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsHandler : MonoBehaviour
{
    public GameObject bgPanel;
    public GameObject optionsPanel;
    public static bool gameIsPaused;
    public GameObject music;
    private AudioSource actualMusic;
    public GameObject scrollView;
    public bool isMatchingGame;
    public bool lastMusicState; // whether music was on before

    public RectTransform area;

    private void Start()
    {
        actualMusic = music.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //HandleClickOutsidePanel();
        //HandleClick();
    }

    void HandleClickOutsidePanel()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {

            if ((Input.GetTouch(i).phase == TouchPhase.Began && optionsPanel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                area.GetComponent<RectTransform>(),
                Input.GetTouch(i).position,
                null)) ||
                (Input.GetMouseButton(0) && optionsPanel.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(
                    area.GetComponent<RectTransform>(),
                    Input.mousePosition,
                    null)))
            {

                optionsPanel.SetActive(false);
                bgPanel.SetActive(false);
                Resume();
            }

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
        lastMusicState = actualMusic.isPlaying;
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
