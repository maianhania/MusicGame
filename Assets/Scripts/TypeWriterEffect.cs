using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour {

    public float delay;
    public string fullText;
    private string currentText = "";

    private void OnEnable()
    {
        StartDisplayText();
    }

    public void StartDisplayText()
    {
        StartCoroutine(ShowText());
    }

    private IEnumerator ShowText()
    {
        for (int i=0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<Text>().text = currentText;
            yield return new WaitForSeconds(delay);
        }
    }
}
