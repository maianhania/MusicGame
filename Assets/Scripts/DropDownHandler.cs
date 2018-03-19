using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour {
    public Dropdown myDropdown;
    public string settingName;

    void Start()
    {
        LoadSettings();
        myDropdown.onValueChanged.AddListener(delegate {
            myDropdownValueChangedHandler(myDropdown);
        });
    }

    private void LoadSettings()
    {
        int savedValue = PlayerPrefs.GetInt(settingName);
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
