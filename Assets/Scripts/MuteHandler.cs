using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteHandler : MonoBehaviour
{
    public GameObject music;
    private AudioSource actualMusic;
    public Button muteButton;
    public Image buttonImage;
    public Sprite unmuteSprite;
    public Sprite muteSprite;
    private bool musicIsMuted;

    public bool isInstructions;

    // Use this for initialization
    void Start ()
    {
        if (!isInstructions)
        {
            actualMusic = music.GetComponent<AudioSource>();
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void HandleClick()
    {
        if (musicIsMuted)
        {
            UnMute();
        }
        else
        {
            Mute();
        }
    }

    public void Mute()
    {
        if (!isInstructions)
        {
            actualMusic.mute = true;
        }
        musicIsMuted = true;
        //pauseButton.GetComponentInParent<GameObject>().SetActive = false;
        if (buttonImage != null)
        {
            Debug.Log("Mute, buttonImage changing sprite");
            buttonImage.sprite = muteSprite;
        }
        else
            Debug.Log("Mute, buttonImage null");
    }

    public void UnMute()
    {
        if (!isInstructions)
        {
            actualMusic.mute = false;
        }
        musicIsMuted = false;
        if (buttonImage != null)
        {
            Debug.Log("UnMute, buttonImage changing sprite");
            buttonImage.sprite = unmuteSprite;
        }

        else
            Debug.Log("UnMute, buttonImage null");
    }
}
