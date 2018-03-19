using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PPText : MonoBehaviour {

    public AudioClip prompt1;
    public AudioClip prompt2;
    public AudioClip prompt3;
    public AudioClip prompt4;
    public AudioClip prompt5;
    public AudioClip musicPrompt1;
    public AudioClip musicPrompt2;
    public AudioSource audioSource;
    public AudioSource audioSource2;

    public Text winTitle;
    public bool winScreen;

    // Use this for initialization
    void Start () {

        //UpdateScoreText();
        if (winScreen)
        {
            //audioSource = GetComponent<AudioSource>();
            SetAchievementPrompts();
        }
    }

    private void SetAchievementPrompts()
    {
        if (PlayerPrefs.GetFloat("Progress") > 0.99f)
        {
            winTitle.text = "That was perfect!";
            audioSource.PlayOneShot(prompt1, 1F);
            audioSource2.PlayOneShot(musicPrompt1, 1F);
        }
        else if (PlayerPrefs.GetFloat("Progress") > 0.9f)
        {
            winTitle.text = "That's impressive!";
            audioSource.PlayOneShot(prompt2, 1F);
            audioSource2.PlayOneShot(musicPrompt1, 1F);
        }
        else if (PlayerPrefs.GetFloat("Progress") > 0.7f)
        {
            winTitle.text = "Amazing!";
            audioSource.PlayOneShot(prompt3, 1F);
            audioSource2.PlayOneShot(musicPrompt1, 1F);

        }
        else if (PlayerPrefs.GetFloat("Progress") > 0.5f)
        {
            winTitle.text = "Not too bad!";
            audioSource.PlayOneShot(prompt4, 1F);
            audioSource2.PlayOneShot(musicPrompt1, 1F);
        }
        else
        {
            winTitle.text = "You can do better!";
            audioSource.PlayOneShot(prompt5, 1F);
            audioSource2.PlayOneShot(musicPrompt2, 1F);
        }
    }
    
    void Update()
    {
        GetComponent<Text>().text = PlayerPrefs.GetInt("Score").ToString();

    }
}
