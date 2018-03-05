using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayHandler : MonoBehaviour
{
    public bool isMatchingGame;

    public GameObject scrollView;
    AutomaticScroller script;
    public GameObject playView;
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
    public GameObject music;
    private AudioSource actualMusic;
    private GameObject[] notes;
    public GameObject[] noteTargets;

    public Button playButton;
    public Image buttonImage;
    public Sprite playSprite;
    public Sprite pauseSprite;

    public static bool firstPlay;

    private void Start()
    {
        gameIsPaused = true;
        //Time.timeScale = 0f;
        firstPlay = true;
        actualMusic = music.GetComponent<AudioSource>();
        Pause();
        script = scrollView.GetComponent<AutomaticScroller>();
        Collider2D[] colliders = GetComponents<Collider2D>();
        List<GameObject> temp = new List<GameObject>();
        foreach (Collider2D col in colliders)
        {
            if (col.gameObject.tag.Contains("Note")) {
                temp.Add(col.gameObject);
            }
        }
        notes = temp.ToArray();
        Debug.Log("Got this many notes: " + notes.Length.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if(isMatchingGame && actualMusic.isPlaying)
        {
            script.Scroll();
        }
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
        Debug.Log("Pause");
        //pauseMenuUI.SetActive(true);
        if (isMatchingGame)
        {
            //scrollView.SetActive(true);
            playView.SetActive(false);
            foreach (GameObject noteTarget in noteTargets)
            {
                Collider2D col = noteTarget.GetComponent<CircleCollider2D>();
                col.enabled = false;
            }
        } else
        {
            pauseMenuUI.SetActive(true);
        }
        if (firstPlay)
        {
            Debug.Log("First play");
            //Time.timeScale = 0f;
            //actualMusic.Pause();
            gameIsPaused = true;
            //pauseButton.GetComponentInParent<GameObject>().SetActive = false;
            if (buttonImage != null)
            {
                Debug.Log("First play, pause, buttonImage changing sprite");
                buttonImage.sprite = playSprite;
            }
        } else
        {
            //Time.timeScale = 0f;
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
    }

    public void Resume()
    {
        foreach (GameObject noteTarget in noteTargets)
        {
            Collider2D col = noteTarget.GetComponent<CircleCollider2D>();
            col.enabled = true;
        }
        Debug.Log("Resume");
        Time.timeScale = 1f;
        if (isMatchingGame)
        {
            //scrollView.SetActive(false);
            script = scrollView.GetComponent<AutomaticScroller>();
            playView.SetActive(true);
        } else
        {
            pauseMenuUI.SetActive(false);
        }
        if (firstPlay)
        {
            Debug.Log("Resume, firstplay");
            //pauseMenuUI.SetActive(false);
            script = scrollView.GetComponent<AutomaticScroller>();
            firstPlay = false;
            actualMusic.Play();
            gameIsPaused = false;
            if (buttonImage != null)
            {
                Debug.Log("Resume, firstplay, buttonImage changing sprite");
                buttonImage.sprite = pauseSprite;
            }

            else
                Debug.Log("Resume, buttonImage null");
        } else
        {
            //pauseMenuUI.SetActive(false);
            //Time.timeScale = 1f;
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
}
