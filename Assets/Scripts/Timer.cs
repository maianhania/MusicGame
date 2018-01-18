using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

    public GameObject textObj;
    public float time;
    public float timeEnd;
    private float timeStart;
    public float timeWait;
    private Text timerSeconds;
    private bool active;

	// Use this for initialization
	void Start () {
        timeStart = Time.time;
        timerSeconds = GetComponent<Text>();
        Destroy(gameObject, timeEnd);
	}
	
	// Update is called once per frame
	void Update () {
        if (active)
        {
            time -= Time.deltaTime;
            timerSeconds.text = time.ToString("f0");
        }
        if (Time.time > timeStart + timeWait)
        {
            textObj.SetActive(true);
            active = true;
        }
	}
}
