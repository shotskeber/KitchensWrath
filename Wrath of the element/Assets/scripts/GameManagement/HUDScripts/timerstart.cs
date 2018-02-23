using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timerstart : MonoBehaviour
{
    //variables

    public GameObject un;
    public GameObject deux;
    public GameObject trois;
    public GameObject start;

    private Vector3 rot;
    private Vector3 rot2;

    public bool troisup;
    public bool deuxup;
    public bool unup;
    public bool startup;

    private int timestart = 0;

    void Start ()
    {
        Time.timeScale = 0F;
    }
	
	void Update ()
    {
        if (trois.transform.position.x >= -80f)
        {
            if (trois.transform.position.x >= 0f)
            {
                trois.transform.position += new Vector3(-2.5f, 0f, 0f);
            }

            if (trois.transform.position.x >= -12f && trois.transform.position.x < 0f)
            {
                trois.transform.position += new Vector3(-1f, 0f, 0f);
            }

            if (trois.transform.position.x >= -80f && trois.transform.position.x < -12f)
            {
                trois.transform.position += new Vector3(-2.5f, 0f, 0f);
            }

            if (trois.transform.position.x <= -80f)
            {
                troisup = true;
            }
        }
        if(troisup)
        {
            if (deux.transform.position.x >= -80f)
            {
                if (deux.transform.position.x >= 0f)
                {
                    deux.transform.position += new Vector3(-2.5f, 0f, 0f);
                }
                if (deux.transform.position.x >= -12f && deux.transform.position.x < 0f)
                {
                    deux.transform.position += new Vector3(-1f, 0f, 0f);
                }
                if (deux.transform.position.x >= -80f && deux.transform.position.x < -12f)
                {
                    deux.transform.position += new Vector3(-2.5f, 0f, 0f);
                }
                if (deux.transform.position.x <= -80f)
                {
                    deuxup = true;
                }
            }
        }
        if (deuxup)
        {
            if (un.transform.position.x >= -80f)
            {
                if (un.transform.position.x >= 0f)
                {
                    un.transform.position += new Vector3(-2.5f, 0f, 0f);
                }
                if (un.transform.position.x >= -12f && un.transform.position.x < 0f)
                {
                    un.transform.position += new Vector3(-1f, 0f, 0f);
                }
                if (un.transform.position.x >= -80f && un.transform.position.x < -12f)
                {
                    un.transform.position += new Vector3(-2.5f, 0f, 0f);
                }
                if (un.transform.position.x <= -80f)
                {
                    unup = true;
                }
            }
        }
        if (unup)
        {
            timestart += 1;
            start.SetActive(true);
            if (timestart >= 10 && !startup)
            {
                rot = new Vector3(0, 0, 5f);
                rot2 = new Vector3(0, 0, -5f);
                if (timestart >= 5 && timestart <= 6)
                {
                    start.transform.rotation = Quaternion.Euler(rot);
                }
                if (timestart >= 7 && timestart <= 8)
                {
                    start.transform.rotation = Quaternion.Euler(rot2);
                }
                if (timestart >= 9 && timestart <= 10)
                {
                    start.transform.rotation = Quaternion.Euler(rot);
                }
                if (timestart >= 10 && timestart <= 11)
                {
                    start.transform.rotation = Quaternion.Euler(rot2);
                }
                if (timestart >= 12 && timestart <= 13)
                {
                    start.transform.rotation = Quaternion.Euler(rot);
                }
                if (timestart >= 14 && timestart <= 15)
                {
                    start.transform.rotation = Quaternion.Euler(rot2);
                }
                if (timestart >= 16 && timestart <= 17)
                {
                    start.transform.rotation = Quaternion.Euler(rot);
                }
                if (timestart >= 18 && timestart <= 19)
                {
                    start.transform.rotation = Quaternion.Euler(rot2);
                }
                if (timestart >= 20 && timestart <= 21)
                {
                    start.transform.rotation = Quaternion.Euler(rot);
                }
                if (timestart >= 22 && timestart <= 23)
                {
                    start.transform.rotation = Quaternion.Euler(rot2);
                }
                if (timestart >= 23 && timestart <= 25)
                {
                    start.transform.rotation = Quaternion.Euler(rot);
                }
                if (timestart >= 26 && timestart <= 27)
                {
                    start.transform.rotation = Quaternion.Euler(rot2);
                }
                if (timestart >= 28 && timestart <= 29)
                {
                    start.transform.rotation = Quaternion.Euler(rot);
                }
                if (timestart >= 30 && timestart <= 31)
                {
                    start.transform.rotation = Quaternion.Euler(rot2);
                }
                if (timestart >= 32 && timestart <= 33)
                {
                    start.transform.rotation = Quaternion.Euler(new Vector3(0,0,0));
                }
            }
            if (timestart >= 32 && !startup)
            {
                Time.timeScale = 1f;
                startup = true;
            }
        }
        if (startup)
        {
            start.SetActive(false);
        }
    }
}
