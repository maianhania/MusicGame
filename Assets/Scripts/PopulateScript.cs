using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateScript : MonoBehaviour {

    public GameObject prefab;

    public int numberToCreate;

	// Use this for initialization
	void Start () {

        Populate();
		
	}

    private void Populate()
    {
        GameObject newObj;

        for (int i = 0; i < numberToCreate; i++)
        {
            newObj = (GameObject)Instantiate(prefab, transform);
            newObj.GetComponent<Image>().color = Random.ColorHSV();
        }
    }
}
