using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreIconHandler : MonoBehaviour {

    public Sprite emoji;
    public Sprite balloon;
    private Image img;

	// Use this for initialization
	void Start () {
        img = GetComponent<Image>();
        UpdateIcon();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateIcon();
    }
    private void UpdateIcon()
    {
        int notesOption = PlayerPrefs.GetInt("Notes");
        switch (notesOption)
        {
            case 0:
                img.sprite = emoji;
                break;
            case 1:
                img.sprite = balloon;
                break;
            default:
                break;
        }
        
    }
}
