using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AngryTarget : MonoBehaviour {

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

    public AudioClip c4;
    public AudioClip d4;
    public AudioClip dis4;
    public AudioClip e4;
    public AudioClip f4_1;
    public AudioClip f4_2;
    public AudioClip f4_3;
    public AudioClip f4_8;
    public AudioClip g4_2;
    public AudioClip g4_3;
    public AudioClip g4_6;
    public AudioClip gis4;

    AudioSource audioSource;
    public bool createMode;
    public GameObject n;
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

        //UpdateSounds();

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
        int particlesOption = PlayerPrefs.GetInt("Sounds");
        switch (particlesOption)
        {
            case 0:
                // Music 
                //b4 = musicBoxClips[0];
                c4 = musicBoxClips[0];
                d4 = musicBoxClips[0];
                dis4 = musicBoxClips[0];
                e4 = musicBoxClips[0];
                f4_1 = musicBoxClips[0];
                f4_2 = musicBoxClips[0];
                f4_3 = musicBoxClips[0];
                f4_8 = musicBoxClips[0];
                g4_2 = musicBoxClips[0];
                g4_3 = musicBoxClips[0];
                g4_6 = musicBoxClips[0];
                gis4 = musicBoxClips[0];
                break;
            case 1:
                // Trumpet
                //b4 = pianoClips[0];
                //c5 = pianoClips[1];
                //e4_1 = pianoClips[2];
                //e4_3 = pianoClips[3];
                //e5_5 = pianoClips[4];
                //fis4 = pianoClips[5];
                //fis5_4 = pianoClips[6];
                //g5 = pianoClips[7];
                break;
            case 2:
                // guitar
                //b4 = guitarClips[0];
                //c5 = guitarClips[1];
                //e4_1 = guitarClips[2];
                //e4_3 = guitarClips[3];
                //e5_5 = guitarClips[4];
                //fis4 = guitarClips[5];
                //fis5_4 = guitarClips[6];
                //g5 = guitarClips[7];
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
            if (col.gameObject.tag.Contains("C4"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(c4, 1F);
                else
                    current_audio = c4;
                //Debug.Log("I'm an B4");
                //audioSource.PlayOneShot(b4, 1F);
            }
            else if (col.gameObject.tag.Contains("D4"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(d4, 1F);
                else
                    current_audio = d4;
                //Debug.Log("I'm a C5");
                //audioSource.PlayOneShot(c5, 1F);
            }
            else if (col.gameObject.tag.Contains("DIS4"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(dis4, 1F);
                else
                    current_audio = dis4;
                //Debug.Log("I'm a C5");
                //audioSource.PlayOneShot(c5, 1F);
            }
            else if (col.gameObject.tag.Contains("E4"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(e4, 1F);
                else
                    current_audio = e4;
                //Debug.Log("I'm a E4-1");
                //audioSource.PlayOneShot(e4_1, 1F);
            }
            else if (col.gameObject.tag.Contains("F4-1"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(f4_1, 1F);
                else
                    current_audio = f4_1;
                //Debug.Log("I'm a E4-3");
                //audioSource.PlayOneShot(e4_3, 1F);
            }
            else if (col.gameObject.tag.Contains("F4-2"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(f4_2, 1F);
                else
                    current_audio = f4_2;
                //Debug.Log("I'm a E4-3");
                //audioSource.PlayOneShot(e4_3, 1F);
            }
            else if (col.gameObject.tag.Contains("F4-3"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(f4_3, 1F);
                else
                    current_audio = f4_3;
                //Debug.Log("I'm a E4-3");
                //audioSource.PlayOneShot(e4_3, 1F);
            }
            else if (col.gameObject.tag.Contains("F4-8"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(f4_8, 1F);
                else
                    current_audio = f4_8;
                //Debug.Log("I'm a E4-3");
                //audioSource.PlayOneShot(e4_3, 1F);
            }
            else if (col.gameObject.tag.Contains("G4-2"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(g4_2, 1F);
                else
                    current_audio = g4_2;
                //Debug.Log("I'm a E5-5");
                //audioSource.PlayOneShot(e5_5, 1F);
            }
            else if (col.gameObject.tag.Contains("G4-3"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(g4_3, 1F);
                else
                    current_audio = g4_3;
                //Debug.Log("I'm a E5-5");
                //audioSource.PlayOneShot(e5_5, 1F);
            }
            else if (col.gameObject.tag.Contains("G4-6"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(g4_6, 1F);
                else
                    current_audio = g4_6;
                //Debug.Log("I'm a E5-5");
                //audioSource.PlayOneShot(e5_5, 1F);
            }
            else if (col.gameObject.tag.Contains("GIS4"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(gis4, 1F);
                else
                    current_audio = gis4;
                //Debug.Log("I'm a FIS4");
                //audioSource.PlayOneShot(fis4, 1F);
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
