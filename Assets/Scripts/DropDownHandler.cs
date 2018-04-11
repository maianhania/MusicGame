using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour {
    public Dropdown myDropdown;
    public string settingName;
    public bool isTuneOption;

    void Start()
    {
        LoadSettings();
        myDropdown.onValueChanged.AddListener(delegate {
            myDropdownValueChangedHandler(myDropdown);
        });
    }

    private void Update()
    {

        if (isTuneOption)
        {
            UpdateList();
        }
    }


    private void UpdateList()
    {
        Debug.Log("Update list of tunes");
        Debug.Log("RecordHandler has " + RecordHandler.compositions.Count + " compositions");
        Hashtable compositions = RecordHandler.compositions;
        if (compositions != null && compositions.Count > 0)
        {//Clear the old options of the Dropdown menu
            myDropdown.ClearOptions();
            //Add the options created in the List above
            List<Dropdown.OptionData> keys = new List<Dropdown.OptionData>();
            foreach (DictionaryEntry de in compositions)
            {
                //Create a temporary option
                Dropdown.OptionData temp = new Dropdown.OptionData();
                //Make the option the data from the TextField
                temp.text = (string) de.Key;
                keys.Add(temp);
            }
            // Add the created list of options
            myDropdown.AddOptions(keys);
            SetDropdownIndex(0);
        }
    }

    private void LoadSettings()
    {
        int savedValue = PlayerPrefs.GetInt(settingName);
        Debug.Log("Load settings for " + settingName + ", the setting value is: " + savedValue);
        SetDropdownIndex(savedValue);
    }

    void Destroy()
    {
        myDropdown.onValueChanged.RemoveAllListeners();
    }

    private void myDropdownValueChangedHandler(Dropdown target)
    {
        Debug.Log(settingName + " value changed to: " + target.value);
        string name = gameObject.transform.parent.name;
        //Debug.Log("Parent name: " + target.value);
        PlayerPrefs.SetInt(settingName, target.value);
    }

    public void SetDropdownIndex(int index)
    {
        myDropdown.value = index;
    }
}
