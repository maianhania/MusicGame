using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundPanel : MonoBehaviour {

    public GameObject bgPanel;
    public GameObject optionsPanel;

	// Use this for initialization
	void Start () {

    }
// Update is called once per frame
void Update () {
        for (int i = 0; i < Input.touchCount; ++i)
        {
            //if (Input.GetTouch(i).phase == TouchPhase.Began)
            //{
            //Vector2 pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(i).position);
            //Debug.Log("Position  " + pos);
            // Get position in pixels
            //if (pos.x > transform.position.x - 0.5 && pos.x < transform.position.x + 0.5 && pos.y < transform.position.y + 0.5 && pos.y > transform.position.y - 0.5)
            //{
            //    if (active)
            if ((Input.GetTouch(i).phase == TouchPhase.Began && optionsPanel.activeSelf &&
            !RectTransformUtility.RectangleContainsScreenPoint(
                optionsPanel.GetComponent<RectTransform>(),
                Input.GetTouch(i).position,
                null)) ||
                (Input.GetMouseButton(0) && optionsPanel.activeSelf && !RectTransformUtility.RectangleContainsScreenPoint(
                    optionsPanel.GetComponent<RectTransform>(),
                    Input.mousePosition,
                    null)))
            //if ((Input.GetTouch(i).phase == TouchPhase.Began || Input.GetMouseButton(0)) && optionsPanel.activeSelf &&
            //(!RectTransformUtility.RectangleContainsScreenPoint(
            //    optionsPanel.GetComponent<RectTransform>(),
            //    Input.GetTouch(i).position,
            //    null) || !RectTransformUtility.RectangleContainsScreenPoint(
            //    optionsPanel.GetComponent<RectTransform>(),
            //    Input.mousePosition,
            //    null)))
            {

                optionsPanel.SetActive(false);
                bgPanel.SetActive(false);
            }

            //}
        }
    }
}
