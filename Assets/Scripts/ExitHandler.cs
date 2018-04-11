using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitHandler : MonoBehaviour {

    public GameObject panel;
    public GameObject settingsPanel;
    public GameObject backgroundPanel;
    public SettingsHandler settingsHandler;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        HideIfClickedOutside();
	}

    private void HideIfClickedOutside()
    {
        if (Input.GetMouseButton(0) && panel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                panel.GetComponent<RectTransform>(),
                Input.mousePosition,
                null))
        {
            panel.SetActive(false);
            backgroundPanel.SetActive(false);
            settingsPanel.SetActive(false);
            settingsHandler.HandleClick();
        }
    }
}
