using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour {
    AudioSource audioSource;
    public LevelManager levelManager;

    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        float progress = Mathf.Clamp01(audioSource.time / audioSource.clip.length);
        //Debug.Log("Progress of music " + progress);

        //Detect the end of the audio source
        if (progress > 0.99f)
        {
            levelManager.LoadLevel("Win");
        }
    }
}
