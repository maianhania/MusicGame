using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveHandler : MonoBehaviour
{
    public InputField titleInput;
    private static int counter;
    public static Hashtable compositions;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    //public void SaveComposition()
    //{
    //    RecordHandler.Stop();
    //    if (RecordHandler.noteTimes.Count != 0)
    //    {
    //        if (titleInput.text != null && titleInput.text != "")
    //        {
    //            Debug.Log("Title provided: " + titleInput.text);
    //            compositions[titleInput.text] = RecordHandler.noteTimes;
    //        }
    //        else
    //        {
    //            Debug.Log("No title provided, using default name");
    //            counter++;
    //            compositions["composition_" + counter] = RecordHandler.noteTimes;
    //        }
    //    }
    //    else
    //    {
    //        titleInput.text = "";
    //        Text placeholderText = titleInput.placeholder.GetComponent<Text>();
    //        placeholderText.text = "No notes to be saved";
    //        placeholderText.color = Color.red;
    //        Debug.Log("No notes to be saved");
    //    }
    //}
}
