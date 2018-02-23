using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class scoreupdate : MonoBehaviour
{
    //variables

    public GameObject gameManager;
    public GameObject circlescore50;
    public GameObject circlescore100;
    public GameObject circlescore150;
    public GameObject circlescore200;
    public GameObject circlescore250;
    public GameObject circlescore300;

    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
    }
	
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (gameManager.GetComponent<gameManager>().pointsToWin <= 300)
            {
                gameManager.GetComponent<gameManager>().pointsToWin += 50;
                if (gameManager.GetComponent<gameManager>().pointsToWin == 350)
                {
                    gameManager.GetComponent<gameManager>().pointsToWin = 50;
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (gameManager.GetComponent<gameManager>().pointsToWin >= 0)
            {
                gameManager.GetComponent<gameManager>().pointsToWin -= 50;
                if (gameManager.GetComponent<gameManager>().pointsToWin == 0)
                {
                    gameManager.GetComponent<gameManager>().pointsToWin = 300;
                }
            }
        }

            if (gameManager.GetComponent<gameManager>().pointsToWin == 50)
        {
            circlescore300.SetActive(false);
            circlescore100.SetActive(false);
            circlescore50.SetActive(true);
        }

        if (gameManager.GetComponent<gameManager>().pointsToWin == 100)
        {
            circlescore50.SetActive(false);
            circlescore150.SetActive(false);
            circlescore100.SetActive(true);
        }

        if (gameManager.GetComponent<gameManager>().pointsToWin == 150)
        {
            circlescore100.SetActive(false);
            circlescore200.SetActive(false);
            circlescore150.SetActive(true);
        }

        if (gameManager.GetComponent<gameManager>().pointsToWin == 200)
        {
            circlescore150.SetActive(false);
            circlescore250.SetActive(false);
            circlescore200.SetActive(true);
        }

        if (gameManager.GetComponent<gameManager>().pointsToWin == 250)
        {
            circlescore300.SetActive(false);
            circlescore200.SetActive(false);
            circlescore250.SetActive(true);
        }

        if (gameManager.GetComponent<gameManager>().pointsToWin == 300)
        {
            circlescore50.SetActive(false);
            circlescore250.SetActive(false);
            circlescore300.SetActive(true);
        }

        if(inputManager.Submit ())
        {
            SceneManager.LoadScene("game");
        }
    }
}
