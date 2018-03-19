using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitPanelManager : MonoBehaviour {

    public GameObject bgPanel;
    public GameObject quitPanel;
    public AudioSource audioSource;
    public AudioClip quit;
    public AudioClip quitPrompt;

    // Use this for initialization
    void Start () {
		
	}
	

	// Update is called once per frame
	void Update () {

        HandleClickOutsidePanel();
		
	}
    void HandleClickOutsidePanel()
    {
        for (int i = 0; i < Input.touchCount; ++i)
        {

            if ((Input.GetTouch(i).phase == TouchPhase.Began && quitPanel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                quitPanel.GetComponent<RectTransform>(),
                Input.GetTouch(i).position,
                null)) ||
                (Input.GetMouseButton(0) && quitPanel.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(
                    quitPanel.GetComponent<RectTransform>(),
                    Input.mousePosition,
                    null)))
            {

                quitPanel.SetActive(false);
                bgPanel.SetActive(false);
            }

        }
    }
    public void EnableQuitPanel()
    {
        bgPanel.SetActive(true);
        quitPanel.SetActive(true);
        StartCoroutine(PlayAnotherSound());
        //audioSource.clip = quitPrompt;
        //audioSource.Play();
    }

    private IEnumerator PlayAnotherSound()
    {
        yield return new WaitForSeconds(0.5f);
        audioSource.clip = quitPrompt;
        audioSource.Play();
    }

    public void DisableQuitPanel()
    {
        bgPanel.SetActive(false);
        quitPanel.SetActive(false);
    }
}
