using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HappyTarget : MonoBehaviour {

    public string targetNoteSound;
    // Particle materials
    public Material bubbleMaterial;
    public Material starMaterial;

    public KeyCode key;
    bool active;
    GameObject note;
    SpriteRenderer sr;
    public int score;
    public Sprite sprite1;
    public Sprite sprite2;

    public AudioClip[] trumpetClips;
    public AudioClip[] musicBoxClips;
    public AudioClip[] guitarClips;

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
    public static bool createMode;
    public GameObject n;
    private AudioClip current_audio;
    public AudioSource backgroundMusic;
    public RecordHandler recordHandler;
    public GameObject createdNotesParent;
    public static Hashtable colours;

    ParticleSystem bubbles;

    public bool playAutomatic; // whether sound played automatically on collision or by tap

    public bool isTapperGame; 

    // Use this for initialization
    void Start () {

        //Debug.Log("This target's position " + transform.position);
        // Reset this game's score to 0
        PlayerPrefs.SetInt("Score", 0);

        // Get target sprite 
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
        if (this.gameObject.transform.GetChild(0))
        {
            bubbles = this.gameObject.transform.GetChild(0).GetComponent<ParticleSystem>();
            bubbles.Stop();
        }
        UpdateParticles();

        if (isTapperGame)
        {
            SetColours();
        }
    }

    private void SetColours()
    {
        colours = new Hashtable();
        colours["E5"] = (Color)new Color32(247, 124, 255, 255);
        colours["D5"] = (Color)new Color32(210, 165, 255, 255);
        colours["C5"] = (Color)new Color32(49, 128, 255, 255);
        colours["A4"] = (Color)new Color32(158, 251, 255, 255); 
        colours["G4"] = (Color)new Color32(121, 255, 112, 255);
        colours["E4"] = (Color)new Color32(247, 255, 122, 255);
        colours["D4"] = (Color)new Color32(255, 124, 66, 255);
        colours["C4"] = (Color)new Color32(255, 0, 0, 255);
    }

    // Update is called once per frame
    void Update()
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
            if (Input.GetMouseButtonDown(0))
                //if (Input.GetMouseButtonDown(0) || Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(key))
            {
                // Create the note                
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
                //Debug.Log("Position  " + pos);
                // Get position in pixels
                if (pos.x > transform.position.x - 0.5 && pos.x < transform.position.x + 0.5 && pos.y < transform.position.y + 0.5 && pos.y > transform.position.y - 0.5)
                {
                    GameObject clone = Instantiate(n, transform.position, Quaternion.identity);
                    clone.GetComponent<SpriteRenderer>().color = (Color)colours[targetNoteSound];
                    clone.transform.parent = createdNotesParent.transform;
                    Debug.Log("Time of note: " +backgroundMusic.time.ToString("#.00"));
                    recordHandler.UpdateTimes(clone, backgroundMusic.time);

                    // Set note tag for appropriate sound
                    switch (targetNoteSound)
                    {
                        case "E5":
                            audioSource.PlayOneShot(e5, 1F);
                            clone.tag = "Note-E5";
                            break;
                        case "D5":
                            audioSource.PlayOneShot(d5, 1F);
                            clone.tag = "Note-D5";
                            break;
                        case "C5":
                            audioSource.PlayOneShot(c5, 1F);
                            clone.tag = "Note-C5";
                            break;
                        case "A4":
                            audioSource.PlayOneShot(a4, 1F);
                            clone.tag = "Note-A4";
                            break;
                        case "G4":
                            audioSource.PlayOneShot(g4, 1F);
                            clone.tag = "Note-G4-long";
                            break;
                        case "E4":
                            audioSource.PlayOneShot(e4, 1F);
                            clone.tag = "Note-E4-long";
                            break;
                        case "D4":
                            audioSource.PlayOneShot(d4, 1F);
                            clone.tag = "Note-D4-long";
                            break;
                        case "C4":
                            audioSource.PlayOneShot(c4, 1F);
                            clone.tag = "Note-C4-long";
                            break;
                        default:
                            break;

                    }
                }       
            }
        }
        else
        {
            HandleTouch();

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
        int particlesOption = PlayerPrefs.GetInt("Sounds-happy");
        switch (particlesOption)
        {
            case 0:
                // Music box   
                e5 = musicBoxClips[0];
                d5 = musicBoxClips[1];
                c5 = musicBoxClips[2];
                a4 = musicBoxClips[3];
                a4_long = musicBoxClips[4];
                g4 = musicBoxClips[5];
                e4 = musicBoxClips[6];
                d4 = musicBoxClips[7];
                c4 = musicBoxClips[8];
                break;
            case 1:
                // Trumpet
                e5 = trumpetClips[0];
                d5 = trumpetClips[1];
                c5 = trumpetClips[2];
                a4 = trumpetClips[3];
                a4_long = trumpetClips[4];
                g4 = trumpetClips[5];
                e4 = trumpetClips[6];
                d4 = trumpetClips[7];
                c4 = trumpetClips[8];
                break;
            case 2:
                //Guitar 
                e5 = guitarClips[0];
                d5 = guitarClips[1];
                c5 = guitarClips[2];
                a4 = guitarClips[3];
                a4_long = guitarClips[4];
                g4 = guitarClips[5];
                e4 = guitarClips[6];
                d4 = guitarClips[7];
                c4 = guitarClips[8];

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
