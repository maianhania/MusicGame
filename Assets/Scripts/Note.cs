using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour {
    Rigidbody2D rb;
    public float speed;
    //float speed = 2.0F;
	// Use this for initialization
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

	void Start () {
        rb.velocity = new Vector2(speed, 0);
	}

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(speed, 0, 0) * Time.deltaTime);
    }


}
