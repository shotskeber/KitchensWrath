using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class buttons : MonoBehaviour
{

    //variables

    public GameObject gameManager;
    public GameObject soundManager;
    public GameObject UIpause;

    void Start()

    {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        soundManager = GameObject.Find("soundManager");

    }

    public void leaveButton()
    {
        Application.Quit();
    }

    public void Resumebutton()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void soundleft()
    {
        soundManager.GetComponent<soundManager>().masterVolume -= 0.25f;

        if (soundManager.GetComponent<soundManager>().masterVolume <= 0f)
        {
            soundManager.GetComponent<soundManager>().masterVolume = 0f;
        }
    }

    public void soundright()
    {
        soundManager.GetComponent<soundManager>().masterVolume += 0.25f;

        if (soundManager.GetComponent<soundManager>().masterVolume >= 1f)
        {
            soundManager.GetComponent<soundManager>().masterVolume = 1f;
        }
    }

	public void rightButton()
    {
        if (gameManager.GetComponent<gameManager>().pointsToWin <= 300)
        {
			gameManager.GetComponent<gameManager> ().pointsToWin += 50;
            if (gameManager.GetComponent<gameManager>().pointsToWin == 350)
            {
                gameManager.GetComponent<gameManager>().pointsToWin = 50;
            }
        }
	}

    public void leftButton()
    {
        if (gameManager.GetComponent<gameManager>().pointsToWin >= 0)
        {
			gameManager.GetComponent<gameManager> ().pointsToWin -= 50;
            if (gameManager.GetComponent<gameManager>().pointsToWin == 0)
            {
                gameManager.GetComponent<gameManager>().pointsToWin = 300;
            }
        }
    }

    //pausemenu: nique ta race

    public void resumebutton()
    {
        UIpause.SetActive(false);
        Time.timeScale = 1F;
    }

    public void mainmenubutto()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        Destroy(gameManager);
        SceneManager.LoadScene("main_menu");
        Time.timeScale = 1F;
    }

    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
