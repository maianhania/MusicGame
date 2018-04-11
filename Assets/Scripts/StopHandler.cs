using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopHandler : MonoBehaviour
{
    public bool isMatchingGame;

    public GameObject scrollView;
    AutomaticScroller script;
    public GameObject playView;
    public GameObject pauseMenuUI;
    public GameObject music;
    private AudioSource actualMusic;
    public GameObject noteParent;
    private GameObject[] notesGameObjects;
    private Note[] notes;
    public GameObject[] noteTargets;

    public float speed;

    public Button playButton;
    public Image buttonImage;
    public Sprite playSprite;
    public Sprite pauseSprite;

    public static bool firstPlay;

    private void Start()
    {
        firstPlay = true;
        actualMusic = music.GetComponent<AudioSource>();
        Transform[] transforms = noteParent.GetComponentsInChildren<Transform>();

        List<GameObject> temp = new List<GameObject>();
        //Collider2D[] colliders = GetComponents<Collider2D>();
        foreach (Transform transfrom in transforms)
        {

            temp.Add(transform.gameObject);

        }
        notesGameObjects = temp.ToArray();

        Debug.Log("Got this many notes game objects: " + notesGameObjects.Length.ToString());
        List<Note> temp2 = new List<Note>();
        foreach (GameObject n in notesGameObjects)
        {
            if (n.GetComponent<Note>())
            {
                Debug.Log("Found note");
            }
            //temp2.Add(n.GetComponent<Note>());
        }
        notes = temp2.ToArray();
        //speed = notes[1].speed;
        Debug.Log("Got this many notes: " + notes.Length.ToString());
        Debug.Log("Notes have speed " + speed.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        if (isMatchingGame && actualMusic.isPlaying)
        {
            script.Scroll();
        }
        //HandleClick();
    }

    public void HandleClick()
    {
        //if (gameIsPaused)
        //{
        //    Resume();
        //}
        //else
        //{
        //    Pause();
        //}
        ResetMusic();
        ResetNotes();
    }

    private void ResetNotes()
    {
        foreach(Note n in notes)
        {
            n.ResetPosition();
        }
    }

    private void ResetMusic()
    {
        actualMusic.Stop();
        actualMusic.Play();
    }

    public void Pause()
    {
        Debug.Log("Pause");
        //pauseMenuUI.SetActive(true);
        if (isMatchingGame)
        {
            scrollView.SetActive(true);
            playView.SetActive(false);
            Time.timeScale = 0f;
            foreach (GameObject noteTarget in noteTargets)
            {
                Collider2D col = noteTarget.GetComponent<CircleCollider2D>();
                col.enabled = false;
            }
        }
        else
        {
            pauseMenuUI.SetActive(true);
        }
        if (firstPlay)
        {
            Debug.Log("First play");
            Time.timeScale = 0f;
            actualMusic.Pause();
            //pauseButton.GetComponentInParent<GameObject>().SetActive = false;
            if (buttonImage != null)
            {
                Debug.Log("First play, pause, buttonImage changing sprite");
                buttonImage.sprite = playSprite;
            }
            else
                Debug.Log("Pause, buttonImage null");
        }
        else
        {
            Time.timeScale = 0f;
            actualMusic.Pause();
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
        Debug.Log("Resume");
        Time.timeScale = 1f;
        foreach (GameObject noteTarget in noteTargets)
        {
            Collider2D col = noteTarget.GetComponent<CircleCollider2D>();
            col.enabled = true;
        }

        if (isMatchingGame)
        {
            scrollView.SetActive(false);
            script = scrollView.GetComponent<AutomaticScroller>();
            playView.SetActive(true);
        }
        else
        {
            pauseMenuUI.SetActive(false);
            playView.SetActive(true);
        }
        if (firstPlay)
        {
            Debug.Log("Resume, firstplay");
            //pauseMenuUI.SetActive(false);
            firstPlay = false;
            actualMusic.Play();
            if (buttonImage != null)
            {
                Debug.Log("Resume, firstplay, buttonImage changing sprite");
                buttonImage.sprite = pauseSprite;
            }

            else
                Debug.Log("Resume, buttonImage null");
        }
        else
        {
            actualMusic.UnPause();
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
