using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

    public GameObject loadingScreen;
    public Slider slider;
    public Text progressText;

    //public void LoadLevel(int sceneIndex)
    //{
    //    StartCoroutine(LoadAsynchronously(sceneIndex));
    //}

    public void LoadLevel(string name)
    {
        //lastLevel = SceneManager.GetActiveScene().name;
        StartCoroutine(LoadAsynchronously(name));

    }
    public void LoadLevelWithDelay(string name)
    {
        StartCoroutine(LoadAsynchronouslyDelay(name));

    }

    private IEnumerator LoadAsynchronouslyDelay(string name)
    {
        yield return new WaitForSeconds(1);
        AsyncOperation op = SceneManager.LoadSceneAsync(name);

        loadingScreen.SetActive(true);

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            slider.value = progress;
            progressText.text = (progress * 100).ToString("0") + "%";
            Debug.Log(progress);

            yield return null;
        }
    }

    private IEnumerator LoadDelay(string name)
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(name);
    }
    IEnumerator LoadAsynchronously (string name)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(name);

        loadingScreen.SetActive(true);

        while (!op.isDone)
        {
            float progress = Mathf.Clamp01(op.progress / .9f);
            slider.value = progress;
            progressText.text = (progress * 100).ToString("0") + "%";
            Debug.Log(progress);

            yield return null;
        }
    }
}
