using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class txtscoregeneral : MonoBehaviour
{
    //variables

    public GameObject gameManager;

    private float p1pts;
    private float p2pts;
    private float p3pts;
    private float p4pts;

    public Text txt1;
    public Text txt2;
    public Text txt3;
    public Text txt4;

    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        p1pts = gameManager.GetComponent<gameManager>().p1Points;
        p2pts = gameManager.GetComponent<gameManager>().p2Points;
        p3pts = gameManager.GetComponent<gameManager>().p3Points;
        p4pts = gameManager.GetComponent<gameManager>().p4Points;

        txt1.text = p1pts.ToString("0");
        txt2.text = p2pts.ToString("0");
        txt3.text = p3pts.ToString("0");
        txt4.text = p4pts.ToString("0");
    }
	
	void Update ()
    {
		
	}
}
