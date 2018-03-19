using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PanelFade : MonoBehaviour {

    public Image image;

	// Use this for initialization
	void Start () {
        image.CrossFadeAlpha(0.0f, 1, false);
        StartCoroutine(DeactivatePanel());
    }

    private IEnumerator DeactivatePanel()
    {
        yield return new WaitForSeconds(1f);
        image.gameObject.SetActive(false);
    }
}
