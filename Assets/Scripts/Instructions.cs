using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {

    public Image img;
    public Sprite[] sprites;
    public Button backButton;
    public Button nextButton;
    public GameObject doneButton;
    public GameObject welcomeText;
    public GameObject pianoIconText;
    public GameObject settingsIconText;
    int currentIndex;
    private bool start;

    public GameObject pianoButton;
    public GameObject settingsButton;

    public AudioSource audioSource;
    public AudioClip welcome;
    public AudioClip settings;
    public AudioClip piano;

    public MuteHandler muteHandler;

    //private bool lastSettings;
    //private bool lastPiano;


    // Use this for initialization
    void Start () {
        //Debug.Log("Sprites number available " + sprites.Length.ToString());
        start = true;

        audioSource.PlayOneShot(welcome);
    }

    public void Back()
    {
        //Debug.Log("Back");
        nextButton.interactable = true;
        if (currentIndex - 1 >= 0) { 
            Debug.Log(currentIndex);
            currentIndex--;
            img.sprite = sprites[currentIndex];
        }
        if (currentIndex == 0)
        {
            backButton.interactable = false;
        }
        if (currentIndex == 2 || currentIndex == 3)
        {
            pianoButton.SetActive(true);
            pianoIconText.SetActive(true);
            if (currentIndex == 3)
                audioSource.PlayOneShot(piano);
        } 
        else
        {
            pianoButton.SetActive(false);
            //Debug.Log("Current Index not about piano");
            pianoIconText.SetActive(false);
        }
        if (currentIndex == 5 || currentIndex == 6)
        {
            settingsButton.SetActive(true);
            settingsIconText.SetActive(true);
            if (currentIndex == 6)
                audioSource.PlayOneShot(settings);
        }
        else
        {
            settingsButton.SetActive(false);
            //Debug.Log("Current Index not about piano");
            settingsIconText.SetActive(false);
        }
    }
    public void Next()
    {
        //Debug.Log("Next");
        if (start)
        {
            welcomeText.gameObject.SetActive(false);
        }
        backButton.interactable = true;
        if (currentIndex + 1 < sprites.Length)
        {
            Debug.Log(currentIndex);
            currentIndex++;
            img.sprite = sprites[currentIndex];
        }

        if (currentIndex == 2 || currentIndex == 3)
        {
            pianoButton.SetActive(true);
            pianoIconText.SetActive(true);
            if (currentIndex == 2)
                audioSource.PlayOneShot(piano);
            if (currentIndex == 3)
                muteHandler.Mute();
        } else
        {
            pianoButton.SetActive(false);
            //Debug.Log("Current Index not about piano");
            pianoIconText.SetActive(false);
            //audioSource.Stop();
        }
        if (currentIndex == 5 || currentIndex == 6)
        {
            settingsButton.SetActive(true);
            settingsIconText.SetActive(true);
            if (currentIndex == 5)
                audioSource.PlayOneShot(settings);
        }
        else
        {
            settingsButton.SetActive(false);
            //Debug.Log("Current Index not about piano");
            settingsIconText.SetActive(false);
            //audioSource.Stop();
        }
        if (currentIndex == sprites.Length - 1)
        {
            nextButton.interactable = false;
            doneButton.SetActive(true);
        }
    }
}
