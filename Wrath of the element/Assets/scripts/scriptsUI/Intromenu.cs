using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Intromenu : MonoBehaviour
{
    
	void Start ()
    {
		
	}
	
	void Update ()
    {
        if (inputManager.Jump_p1())
        {
            SceneManager.LoadScene("main_menu");
        }
        if (inputManager.Jump_p2())
        {
            SceneManager.LoadScene("main_menu");
        }
        if (inputManager.Jump_p3())
        {
            SceneManager.LoadScene("main_menu");
        }
        if (inputManager.Jump_p4())
        {
            SceneManager.LoadScene("main_menu");
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("main_menu");
        }
    }
}
