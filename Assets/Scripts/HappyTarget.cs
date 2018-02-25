using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyTarget : MonoBehaviour {

    // Particle materials
    public Material bubbleMaterial;
    public Material starMaterial;

    public KeyCode key;
    bool active = false;
    GameObject note;
    SpriteRenderer sr;
    public int score;
    public Sprite sprite1;
    public Sprite sprite2;

    public AudioClip e5;
    public AudioClip d5;
    public AudioClip c5;
    public AudioClip a4;
    public AudioClip a4_long;
    public AudioClip g4;
    public AudioClip e4;
    public AudioClip d4;
    public AudioClip c4;
    AudioSource audioSource;
    public bool createMode;
    public GameObject n;
    private AudioClip current_audio;

    ParticleSystem bubbles;

    public bool playAutomatic; // whether sound played automatically on collision or by tap

    // Use this for initialization
    void Start () {

        //Debug.Log("This target's position " + transform.position);
        // Reset this game's score to 0
        PlayerPrefs.SetInt("Score", 0);

        // Get target sprite 
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        bubbles = this.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
        bubbles.Stop();
    }

    // Update is called once per frame
    void Update()
    {

        //Debug.Log("Score: " + score);
        //Debug.Log("Score text " + text.text);

        UpdateParticles();

        if (playAutomatic && active)
        {
            bubbles.Play();
            Destroy(note);
            UpdateScore();
            active = false;
        }
        else
        {
            HandleTouch();

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

    void OnTriggerEnter2D(Collider2D col)
    {
        //Debug.Log("OnTriggerEnter2D");
        active = true;
        if (col.gameObject.tag.Contains("Note"))
        {
            //Debug.Log("Note");
            note = col.gameObject;
            if (col.gameObject.tag.Contains("E5"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(e5, 1F);
                else
                    current_audio = e5;
                
                //Debug.Log("I'm an E5");
            }
            else if (col.gameObject.tag.Contains("D5"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(d5, 1F);
                else
                    current_audio = d5;

                //Debug.Log("I'm a D5");
                //
            } else if (col.gameObject.tag.Contains("C5"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(c5, 1F);
                else
                    current_audio = c5;
                //Debug.Log("I'm a C5");
                //audioSource.PlayOneShot(c5, 1F);
            }
            else if (col.gameObject.tag.Contains("A4-long"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(a4_long, 1F);
                else
                    current_audio = a4_long;
                //Debug.Log("I'm a A4-long");
                //audioSource.PlayOneShot(a4_long, 1F);
            }
            else if (col.gameObject.tag.Contains("A4") && !col.gameObject.tag.Contains("A4-long"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(a4, 1F);
                else
                    current_audio = a4;
                //Debug.Log("I'm a A4");
                //
            }
            else if (col.gameObject.tag.Contains("G4-long"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(g4, 1F);
                else
                    current_audio = g4;
                //Debug.Log("I'm a G4-long");
                //
            }
            else if (col.gameObject.tag.Contains("E4-long"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(e4, 1F);
                else
                    current_audio = e4;
                //Debug.Log("I'm a E4-long");
                //
            }
            else if (col.gameObject.tag.Contains("D4-long"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(d4, 1F);
                else
                    current_audio = d4; 
                //Debug.Log("I'm a D4-long");
                //audioSource.PlayOneShot(d4, 1F);
            }
            else if (col.gameObject.tag.Contains("C4-long"))
            {
                if (playAutomatic)
                    audioSource.PlayOneShot(c4, 1F);
                else
                    current_audio = c4;
                //Debug.Log("I'm a C4-long");
                //audioSource.PlayOneShot(c4, 1F);
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
