using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownHandler : MonoBehaviour {
    public Dropdown myDropdown;
    public string settingName;

    void Start()
    {
        myDropdown.onValueChanged.AddListener(delegate {
            myDropdownValueChangedHandler(myDropdown);
        });
    }
    void Destroy()
    {
        myDropdown.onValueChanged.RemoveAllListeners();
    }

    private void myDropdownValueChangedHandler(Dropdown target)
    {
        //Debug.Log("selected: " + target.value);
        string name = gameObject.transform.parent.name;
        //Debug.Log("Parent name: " + target.value);
        PlayerPrefs.SetInt(settingName, target.value);
    }

    public void SetDropdownIndex(int index)
    {
        myDropdown.value = index;
    }
}