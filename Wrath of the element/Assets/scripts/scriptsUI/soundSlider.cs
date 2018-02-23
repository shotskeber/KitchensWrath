using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSlider : MonoBehaviour
{

    //variables

    public GameObject module;
    public GameObject soundManager;

    void Start ()
    {
        soundManager = GameObject.Find("soundManager");
    }
	
	void Update ()
    {
        if (module.GetComponent<GameObject>().transform.position.x == 0)
        {
            soundManager.GetComponent<soundManager>().masterVolume = 0.5f;
        }
        if (module.GetComponent<GameObject>().transform.position.x == 2.5)
        {
            soundManager.GetComponent<soundManager>().masterVolume = 0.75f;
        }
        if (module.GetComponent<GameObject>().transform.position.x == 5)
        {
            soundManager.GetComponent<soundManager>().masterVolume = 1f;
        }
        if (module.GetComponent<GameObject>().transform.position.x == -2.5)
        {
            soundManager.GetComponent<soundManager>().masterVolume = 0.25f;
        }
        if (module.GetComponent<GameObject>().transform.position.x == -5)
        {
            soundManager.GetComponent<soundManager>().masterVolume = 0f;
        }
    }
}
