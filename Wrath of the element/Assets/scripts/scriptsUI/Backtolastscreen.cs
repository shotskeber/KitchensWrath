using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Backtolastscreen : MonoBehaviour
{

	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (inputManager.Cancel())
        {
            SceneManager.LoadScene("main_menu");
        }

    }
}
