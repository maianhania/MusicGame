using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SadTarget : MonoBehaviour {

    // Particle materials
    public Material bubbleMaterial;
    public Material starMaterial;

    ParticleSystem bubbles;

    public KeyCode key;
    bool active = false;
    GameObject note;
    SpriteRenderer sr;
    public Sprite sprite1;
    public Sprite sprite2;

    //public Hashtable clips;

    public AudioClip[] pianoClips;
    public AudioClip[] musicBoxClips;
    public AudioClip[] guitarClips;

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
    private GameObject n;
    private AudioClip current_audio;

    public bool playAutomatic; // whether sound played automatically on collision or by tap

    // Use this for initialization
    void Start () {
        // Reset this game's score to 0
        PlayerPrefs.SetInt("Score", 0);
        // Get target sprite 
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        bubbles = this.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
        bubbles.Stop();
        UpdateParticles();
    }
	
	// Update is called once per frame
	void Update ()
    {
        UpdateParticles();
        UpdateSounds();

        if (playAutomatic && active)
        {
            bubbles.Play();
            Destroy(note);
            UpdateScore();
            active = false;
        }
        if (createMode)
        {
            if (Input.GetKeyDown(key))
            {
                Instantiate(n, transform.position, Quaternion.identity);
            }
        }


        else
        {
            HandleTouch();

            //if (createMode)
            //{
            //    if (Input.GetKeyDown(key))
            //    {
            //        Instantiate(n, transform.position, Quaternion.identity);
            //    }
            //}


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
    }

    private void HandleTouch()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                //Debug.Log("Position  " + pos);
                // Get position in pixels
                if (pos.x > transform.position.x - 0.5 && pos.x < transform.position.x + 0.5 && pos.y < transform.position.y + 0.5 && pos.y > transform.position.y - 0.5)
                {
                    if (active)
                    {
                        //Debug.Log("I'm playing");
                        bubbles.Play();
                        audioSource.PlayOneShot(current_audio, 1F);
                        Destroy(note);
                        UpdateScore();
                        active = false;
                    }

                    StartCoroutine(Pressed());
                }

                /*// Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                // Create a particle if hit
                if (Physics.Raycast(ray))
                    Instantiate(particle, transform.position, transform.rotation);*/
            }
        }
    }

    private void UpdateParticles()
    {
        int particlesOption = PlayerPrefs.GetInt("Particles");
        switch (particlesOption)
        {
            case 0:
                bubbles.GetComponent<ParticleSystemRenderer>().material = starMaterial;
                break;
            case 1:
                bubbles.GetComponent<ParticleSystemRenderer>().material = bubbleMaterial;
                break;
            default:
                break;

        }
    }

    private void UpdateSounds()
    {
        int particlesOption = PlayerPrefs.GetInt("Sounds-sad");
        switch (particlesOption)
        {
            case 0:
                // Music box
                b4 = musicBoxClips[0];
                c5 = musicBoxClips[1];
                e4_1 = musicBoxClips[2];
                e4_3 = musicBoxClips[3];
                e5_5 = musicBoxClips[4];
                fis4 = musicBoxClips[5];
                fis5_4 = musicBoxClips[6];
                g5 = musicBoxClips[7];
                break;
            case 1:
                // Piano
                b4 = pianoClips[0];
                c5 = pianoClips[1];
                e4_1 = pianoClips[2];
                e4_3 = pianoClips[3];
                e5_5 = pianoClips[4];
                fis4 = pianoClips[5];
                fis5_4 = pianoClips[6];
                g5 = pianoClips[7];
                break;
            case 2:
                // guitar
                b4 = guitarClips[0];
                c5 = guitarClips[1];
                e4_1 = guitarClips[2];
                e4_3 = guitarClips[3];
                e5_5 = guitarClips[4];
                fis4 = guitarClips[5];
                fis5_4 = guitarClips[6];
                g5 = guitarClips[7];
                break;

                
            default:
                break;

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
                if (playAutomatic)
                    audioSource.PlayOneShot(b4, 1F);
                else
                    current_audio = b4;
                //Debug.Log("I'm an B4");
                //audioSource.PlayOneShot(b4, 1F);
            }
            else if (col.gameObject.tag.Contains("C5"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(c5, 1F);
                else
                    current_audio = c5;
                //Debug.Log("I'm a C5");
                //audioSource.PlayOneShot(c5, 1F);
            }
            else if (col.gameObject.tag.Contains("E4_1"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(e4_1, 1F);
                else
                    current_audio = e4_1;
                //Debug.Log("I'm a E4-1");
                //audioSource.PlayOneShot(e4_1, 1F);
            }
            else if (col.gameObject.tag.Contains("E4_3"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(e4_3, 1F);
                else
                    current_audio = e4_3;
                //Debug.Log("I'm a E4-3");
                //audioSource.PlayOneShot(e4_3, 1F);
            }
            else if (col.gameObject.tag.Contains("E5_5"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(e5_5, 1F);
                else
                    current_audio = e5_5;
                //Debug.Log("I'm a E5-5");
                //audioSource.PlayOneShot(e5_5, 1F);
            }
            else if (col.gameObject.tag.Contains("FIS4"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(fis4, 1F);
                else
                    current_audio = fis4;
                //Debug.Log("I'm a FIS4");
                //audioSource.PlayOneShot(fis4, 1F);
            }
            else if (col.gameObject.tag.Contains("FIS5_4"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(fis5_4, 1F);
                else
                    current_audio = fis5_4;
                //Debug.Log("I'm a FIS5-4");
                //audioSource.PlayOneShot(fis5_4, 1F);
            }
            else if (col.gameObject.tag.Contains("G5"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(g5, 1F);
                else
                    current_audio = g5;
                //Debug.Log("I'm a G5");
                //audioSource.PlayOneShot(g5, 1F);
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
        sr.sprite = sprite2;
        yield return new WaitForSeconds(0.1f);
        sr.sprite = sprite1;
    }

    void UpdateScore()
    {
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
    }

}
