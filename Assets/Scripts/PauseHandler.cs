using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseHandler : MonoBehaviour {

    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject music;
    private AudioSource actualMusic;

    public Button pauseButton;
    public Image buttonImage;
    public Sprite playSprite;
    public Sprite pauseSprite;

    private void Start()
    {
        gameIsPaused = false;
        actualMusic = music.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

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
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        actualMusic.Pause();
        gameIsPaused = true;
        //pauseButton.GetComponentInParent<GameObject>().SetActive = false;
        if (buttonImage != null)
        {
            Debug.Log("Pause, buttonImage changing sprite");
            buttonImage.sprite = playSprite;
        }
        else
            Debug.Log("Pause, buttonImage null");
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        actualMusic.UnPause();
        gameIsPaused = false;
        if (buttonImage != null)
        {
            Debug.Log("Resume, buttonImage changing sprite");
            buttonImage.sprite = pauseSprite;
        }
            
        else
            Debug.Log("Resume, buttonImage null");
    }
}
