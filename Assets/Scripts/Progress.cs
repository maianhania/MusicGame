using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour {
    //public int total;
    public Slider slider;
    //public Text progressText;
    public AudioSource audioSource;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update()
    {
        //float percentage = (float) (PlayerPrefs.GetInt("Score") / total);
        //GetComponent<Text>().text = percentage.ToString("0.00");
        float progress = Mathf.Clamp01(audioSource.time / audioSource.clip.length);
        //float progress = (float)PlayerPrefs.GetInt("Score") / (float)total;
        slider.value = progress;
        //progressText.text = (progress * 100).ToString("0") + "%";
        UpdateProgress(progress);
    }



    void UpdateProgress(float progress)
    {
        PlayerPrefs.SetFloat("Progress", progress);
    }
}
