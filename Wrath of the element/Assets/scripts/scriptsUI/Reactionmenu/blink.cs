using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blink : MonoBehaviour
{
    public GameObject txt;

    public int timerblink = 0;

	void Start ()
    {
		
	}
	
	void Update ()
    {

        timerblink += 1;

        if(timerblink == 35)
        {
            txt.SetActive(false);
        }

        if(timerblink == 45)
        {
            txt.SetActive(true);
            timerblink = 0;
        }
	}
}
