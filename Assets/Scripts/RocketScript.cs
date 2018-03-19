using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour {

	public float velX = 5f; 	// contains X velocity, can be modified in inspector
	float velY = 0f; 			// contains Y velocity which is 0
	Rigidbody2D rb;				// rigidBody2D component reference
	public float lifeTime = 5f;	// life time of a rocket, can be modified in inspector
    public ParticleSystem explosion;
    //public AudioSource audioSource;
    //public AudioClip boom;
    private bool alive;
    AudioSource explosionSound;


    void Awake()
	{
		// reverse rocket sprite if rocket flies in negative X direction

		Vector3 localScale = transform.localScale;
		if (velX < 0) {
			localScale.x *= -1;
			transform.localScale = localScale;
		}
	}

	// Use this for initialization
	void Start () {

		rb = GetComponent<Rigidbody2D> (); // initiate rigidBody component

        explosionSound = GetComponent<AudioSource>();
        explosion.Stop();
        alive = true;
    }
	
	// Update is called once per frame
	void Update () {
        HandleTouch();

		rb.velocity = new Vector2 (velX, velY); // set velocity to the rocket
        if (alive)
		    Invoke ("DestroyGameobject", lifeTime); // invoke destroy rocket function after lifeTime ran out
		
	}

	void DestroyGameobject ()
	{
		foreach (Transform child in transform) {			//
			child.GetComponent<ParticleSystem> ().Stop ();	// stop children to emit particles and destroy them in 3 seconds
			Destroy (child.gameObject, 3f);					//
		}
		transform.DetachChildren (); 	// detach children to make particles be visible after rocket is destroyed
		Destroy (gameObject);			// destroy rocket
	}

    private void HandleTouch()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
                Debug.Log("Position  " + pos);
                Debug.Log("Rocket position " + transform.position);
                // Get position in pixels
                if (pos.x > transform.position.x - 1 && pos.x < transform.position.x + 1 && pos.y < transform.position.y + 1 && pos.y > transform.position.y - 1)
                {

                    Debug.Log("Rocket touched");
                    //audioSource.PlayOneShot(boom, 1F);
                    explosionSound.Play();
                    explosion.Play();
                    Destroy(gameObject, 0.7f);
                    alive = false;
                }

                /*// Construct a ray from the current touch coordinates
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                // Create a particle if hit
                if (Physics.Raycast(ray))
                    Instantiate(particle, transform.position, transform.rotation);*/
            }
        }
    }
}
