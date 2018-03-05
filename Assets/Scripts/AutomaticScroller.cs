using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutomaticScroller : MonoBehaviour {

    ScrollRect sr;
    bool left;

	// Use this for initialization
	void Start () {
        sr = GetComponent<ScrollRect>();
        left = true;
	}
	
	// Update is called once per frame
	void Update () {

    }

    public void Scroll()
    {
        if (left && sr.horizontalNormalizedPosition > 0f)
        {
            //Debug.Log("Scrolling to left");
            sr.ScrollToLeft(0.00025f);
        }
        else if (!left && sr.horizontalNormalizedPosition < 1f)
        {
            //Debug.Log("Scrolling to right");
            //sr.ScrollToRight(0.00047f);
        }
        else if (sr.horizontalNormalizedPosition > 0.9)
        {
            //Debug.Log("Setting scrolling direction to left");
            left = true;
        }
        else if (sr.horizontalNormalizedPosition < 0.1)
        {
            //Debug.Log("Setting scrolling direction to right");
            left = false;
        }
    }
}
