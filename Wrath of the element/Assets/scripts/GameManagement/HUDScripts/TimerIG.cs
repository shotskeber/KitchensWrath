using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerIG : MonoBehaviour
{

    //variables
    public GameObject textTemp;
    public float timer = 45f;
    public GameObject gameManager;

	void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");   
    }
	
	void Update ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = 0;
        }

        //textTemp = GameObject.Find("timer");
        //textTemp.GetComponent<Text>().text = "" + timer.ToString("0");

        if(timer == 0)
        {
            gameManager.GetComponent<gameManager>().rounds += 1;
            SceneManager.LoadScene("betweenGame");
        }


    }
}
