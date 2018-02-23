using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundOptions : MonoBehaviour
{

    //variables
	public int volume = 50;

    public GameObject soundManager;

	void Start ()
    {
        soundManager = GameObject.Find("soundManager");
    }
	
	void Update ()
    {
        GameObject textTemp = GameObject.Find("volume");
		textTemp.GetComponent<Text>().text = "" + soundManager.GetComponent<soundManager>().masterVolume*100;
    }

}
