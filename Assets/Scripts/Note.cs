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
    //float speed = 2.0F;
    // Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

	void Start () {
        rb.velocity = new Vector2(speed, 0);
	}

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
        UpdateNotes();
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
