using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RecordHandler : MonoBehaviour {
    
    public static Hashtable noteTimes;
    public static Hashtable compositions;
    public InputField titleInput;
    private static int counter;
    public GameObject saveBackgroundPanel;
    public GameObject savePanel;
    public SettingsHandler settingsHandler;
    public GameObject saveConfirmationPanel;
    public Text confirmationText;

    public Image buttonImage;
    public Sprite recordSprite;
    public Sprite stopSprite; 


    // Use this for initialization
    void Start () {
        
        noteTimes = new Hashtable();
        if (compositions == null)
        {
            compositions = new Hashtable();
        }
	}
	
	// Update is called once per frame
	void Update () {
        //if (createdNotesParent.transform.childCount == 1)
        //{
        //    createdNotesParent.transform.position = createdNotesParent.GetComponentInChildren<Transform>().position;
        //    firstCreatedNote = createdNotesParent.transform.GetChild(0).gameObject;
        //}
    }

    public void HandleClick()
    {
        if (!HappyTarget.createMode)
        {
            Record();
        } else
        {
            Stop();
        }
    }

    private void Record()
    {
        HappyTarget.createMode = true;
        buttonImage.sprite = stopSprite; 
    }

    public void Stop()
    {
        HappyTarget.createMode = false;
        settingsHandler.Pause();
        buttonImage.sprite = recordSprite;
        saveBackgroundPanel.SetActive(true);
        savePanel.SetActive(true);
    }

    public void UpdateTimes(GameObject note, float time)
    {
        if (HappyTarget.createMode)
        {
            Debug.Log("Added new note");
            noteTimes.Add(note, time);
        }
    }



    public void SaveComposition()
    {
        //Stop();

        if (RecordHandler.noteTimes.Count != 0)
        {
            if (titleInput.text != null && titleInput.text != "")
            {
                Debug.Log("Title provided: " + titleInput.text);
                if (!compositions.Contains(titleInput.text))
                {
                    compositions.Add(titleInput.text, RecordHandler.noteTimes);
                } else
                {
                    compositions[titleInput.text] = RecordHandler.noteTimes;
                }
                StartCoroutine(ConfirmSaving(titleInput.text));
            }
            else
            {
                counter++;
                string name = "composition_" + counter;
                Debug.Log("No title provided, using default name " + name);
                if (!compositions.Contains(name))
                {
                    compositions.Add(name, RecordHandler.noteTimes);
                } else
                {
                    compositions[name] = RecordHandler.noteTimes;
                }

                StartCoroutine(ConfirmSaving(name));
            }
        }
        else
        {
            titleInput.text = "";
            Text placeholderText = titleInput.placeholder.GetComponent<Text>();
            placeholderText.text = "No notes to be saved";
            placeholderText.color = Color.red;
            Debug.Log("No notes to be saved");
        }
    }

    private IEnumerator ConfirmSaving(string title)
    {
        //yield return new WaitForSeconds(1f);
        Time.timeScale = 1;
        savePanel.SetActive(false);
        saveConfirmationPanel.SetActive(true);
        confirmationText.text = "Your tune was saved as " + title;
        yield return new WaitForSeconds(2f);
        saveConfirmationPanel.SetActive(false);
        confirmationText.text = "After deactivating save confirmation panel ";
        saveBackgroundPanel.SetActive(false);
        settingsHandler.Resume();
        Debug.Log("Now have this many compositions saved: " + compositions.Count);
    }

    public void ResetPlaceholder()
    {
        Text placeholderText = titleInput.placeholder.GetComponent<Text>();
        placeholderText.text = "Enter title...";
        placeholderText.color = Color.grey;
    }

}
