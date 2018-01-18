using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SadTarget : MonoBehaviour {

    public KeyCode key;
    bool active = false;
    GameObject note;
    SpriteRenderer sr;
    public Sprite sprite1;
    public Sprite sprite2;
    public AudioClip b4;
    public AudioClip c5;
    public AudioClip e4_1;
    public AudioClip e4_3;
    public AudioClip e5_5;
    public AudioClip fis4;
    public AudioClip fis5_4;
    public AudioClip g5;
    AudioSource audioSource;
    public bool createMode;
    public GameObject n;
    private AudioClip current_audio;

    // Use this for initialization
    void Start () {
        // Reset this game's score to 0
        PlayerPrefs.SetInt("Score", 0);
        // Get target sprite 
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }


		if (Input.GetKeyDown(key))
        {
            StartCoroutine(Pressed());
            if (active)
            {
                //Debug.Log("I'm playing");
                //audioSource.PlayOneShot(current_audio, 1F);
                Destroy(note);
                UpdateScore();
                active = false;
            }                
        }
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("OnTriggerEnter2D");
        active = true;
        if (col.gameObject.tag.Contains("Note"))
        {
            //Debug.Log("Note");
            note = col.gameObject;
            if (col.gameObject.tag.Contains("B4"))
            {
                current_audio = b4;
                Debug.Log("I'm an B4");
                audioSource.PlayOneShot(b4, 1F);
            }
            else if (col.gameObject.tag.Contains("C5"))
            {
                current_audio = c5;
                Debug.Log("I'm a C5");
                audioSource.PlayOneShot(c5, 1F);
            }
            else if (col.gameObject.tag.Contains("E4_1"))
            {
                current_audio = e4_1;
                Debug.Log("I'm a E4-1");
                audioSource.PlayOneShot(e4_1, 1F);
            }
            else if (col.gameObject.tag.Contains("E4_3"))
            {
                current_audio = e4_3;
                Debug.Log("I'm a E4-3");
                audioSource.PlayOneShot(e4_3, 1F);
            }
            else if (col.gameObject.tag.Contains("E5_5"))
            {
                current_audio = e5_5;
                Debug.Log("I'm a E5-5");
                audioSource.PlayOneShot(e5_5, 1F);
            }
            else if (col.gameObject.tag.Contains("FIS4"))
            {
                current_audio = fis4;
                Debug.Log("I'm a FIS4");
                audioSource.PlayOneShot(fis4, 1F);
            }
            else if (col.gameObject.tag.Contains("FIS5_4"))
            {
                current_audio = fis5_4;
                Debug.Log("I'm a FIS5-4");
                audioSource.PlayOneShot(fis5_4, 1F);
            }
            else if (col.gameObject.tag.Contains("G5"))
            {
                current_audio = g5;
                Debug.Log("I'm a G5");
                audioSource.PlayOneShot(g5, 1F);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        //Debug.Log("OnTriggerExit2D");
        active = false;
    }

    IEnumerator Pressed()
    {
        Color old = sr.color;
        sr.sprite = sprite2;
        sr.color = new Color(0, 0, 0);
        yield return new WaitForSeconds(0.05f);
        sr.color = old;
        sr.sprite = sprite1;

        //sr.sprite = sprite2;
        //yield return new WaitForSeconds(0.1f);
        //sr.sprite = sprite1;

        //gameObject.GetComponent<Image>().;
    }

    void UpdateScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
    }
}
