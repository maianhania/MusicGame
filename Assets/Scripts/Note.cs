using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Note : MonoBehaviour {
    Rigidbody2D rb;
    public float speed;
    public bool isCustomisable;

    SpriteRenderer sr;
    public Sprite balloon;
    public Sprite emoji;
    public Color color;

    private Vector2 originalPosition;
    //float speed = 2.0F;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        originalPosition = gameObject.transform.position;
    }

	void OnEnable () {
        rb.velocity = new Vector2(speed, 0);
        UpdateNotes();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Note update");
        //transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
        UpdateNotes();
    }

    public void ResetPosition()
    {
        gameObject.transform.position = originalPosition;
    }

    private void UpdateNotes()
    {
        if (isCustomisable)
        {
            int notesOption = PlayerPrefs.GetInt("Notes");
            switch (notesOption)
            {
                case 0:
                    sr.sprite = emoji;
                    break;
                case 1:
                    sr.sprite = balloon;
                    break;
                default:
                    break;
            }
        }
    }
}
