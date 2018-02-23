using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scrollBar : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Vertical") > 0)
        {
            gameObject.GetComponentInChildren<Scrollbar>().value += 0.0035f;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            gameObject.GetComponentInChildren<Scrollbar>().value -= 0.0035f;
        }

    }
}
