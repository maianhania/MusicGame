using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleTarget : MonoBehaviour
{

    public KeyCode key;
    bool active = false;
    GameObject note;
    SpriteRenderer sr;
    public int score;
    public Sprite sprite1;
    public Sprite sprite2;

    AudioSource audioSource;
    public AudioClip e5;
    public AudioClip d5;
    public AudioClip c5;
    public AudioClip a4;
    public AudioClip a4_long;
    public AudioClip g4;
    public AudioClip e4;
    public AudioClip d4;
    public AudioClip c4;
    public GameObject n;
    private AudioClip current_audio;

    // Use this for initialization
    void Start()
    {
        // Reset this game's score to 0
        PlayerPrefs.SetInt("Score", 0);
        // Get target sprite 
        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Score: " + score);
        //Debug.Log("Score text " + text.text);

        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                Debug.Log("Position  " + pos);
                // Get position in pixels
                if (pos.x > transform.position.x - 0.5 && pos.x < transform.position.x + 0.5 && pos.y < transform.position.y + 0.5 && pos.y > transform.position.y - 0.5)
                {
                    if (active)
                    {
                        //Debug.Log("I'm playing");
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
                current_audio = e5;
                //Debug.Log("I'm an E5");
                //audioSource.PlayOneShot(e5, 1F);
            }
            else if (col.gameObject.tag.Contains("D5"))
            {
                current_audio = d5;
                //Debug.Log("I'm a D5");
                //audioSource.PlayOneShot(d5, 1F);
            }
            else if (col.gameObject.tag.Contains("C5"))
            {
                current_audio = c5;
                //Debug.Log("I'm a C5");
                //audioSource.PlayOneShot(c5, 1F);
            }
            else if (col.gameObject.tag.Contains("A4-long"))
            {
                current_audio = a4_long;
                //Debug.Log("I'm a A4-long");
                //audioSource.PlayOneShot(a4_long, 1F);
            }
            else if (col.gameObject.tag.Contains("A4") && !col.gameObject.tag.Contains("A4-long"))
            {
                current_audio = a4;
                //Debug.Log("I'm a A4");
                //audioSource.PlayOneShot(a4, 1F);
            }
            else if (col.gameObject.tag.Contains("G4-long"))
            {
                current_audio = g4;
                //Debug.Log("I'm a G4-long");
                //audioSource.PlayOneShot(g4, 1F);
            }
            else if (col.gameObject.tag.Contains("E4-long"))
            {
                current_audio = e4;
                //Debug.Log("I'm a E4-long");
                //audioSource.PlayOneShot(e4, 1F);
            }
            else if (col.gameObject.tag.Contains("D4-long"))
            {
                current_audio = d4;
                //Debug.Log("I'm a D4-long");
                //audioSource.PlayOneShot(d4, 1F);
            }
            else if (col.gameObject.tag.Contains("C4-long"))
            {
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
        //Color old = sr.color;
        //sr.sprite = sprite2;
        //sr.color = new Color(0, 0, 0);
        //yield return new WaitForSeconds(0.05f);
        //sr.color = old;
        //sr.sprite = sprite1;

        sr.sprite = sprite2;
        yield return new WaitForSeconds(0.1f);
        sr.sprite = sprite1;

        //gameObject.GetComponent<Image>().;
    }

    void UpdateScore()
    {
        //score += 1;
        PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + 1);
        //text.text = score.ToString();
    }
}
