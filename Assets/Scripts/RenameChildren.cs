using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenameChildren : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Transform[] allChildren = gameObject.GetComponentsInChildren<Transform>();
        int i = 1;
        foreach (Transform child in allChildren)
        {
            child.name = "Note_"+ i;
            i++;
        }
    }
}
