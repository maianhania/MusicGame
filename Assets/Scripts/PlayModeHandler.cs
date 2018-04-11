using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayModeHandler : MonoBehaviour {

    public AudioSource backgroundMusic;
    public float speed;
    public GameObject targetParent;
    private HappyTarget[] targets;

    // Use this for initialization
    void Start () {
        targets = targetParent.GetComponentsInChildren<HappyTarget>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    public void Play()
    {
        Debug.Log("Resetting");
        // Reset player score
        PlayerPrefs.SetInt("Score", 0);
        ResetNotes();
        ResetMusic();

    }

    private void ResetNotes()
    {
        //Hashtable copyNoteTimes = RecordHandler.noteTimes;
        Hashtable copyNoteTimes = (Hashtable)RecordHandler.noteTimes.Clone();
        foreach (DictionaryEntry entry in copyNoteTimes)
        {
            GameObject note = entry.Key as GameObject;
            float time = (float) entry.Value;
            note.transform.position = new Vector2(-speed * time + 6, note.transform.position.y);
        }

        //foreach (HappyTarget target in targets)
        //{
        //    target.playAutomatic = true;
        //}
    }

    private void ResetMusic()
    {
        backgroundMusic.Stop();
        backgroundMusic.Play();
    }
}
