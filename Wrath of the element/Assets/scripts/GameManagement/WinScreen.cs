using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    //variables

    public GameObject gameManager;
    private float ptstowin;
    public Image img;

    public Sprite imgp1;

    private float pw;
    private float winner;

    public Sprite[] skins;

    public Text p1;
    public Text p2;
    public Text p3;
    public Text p4;

    public Text rounds;

    void Start ()
    {
        Cursor.visible = true;
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        winner = gameManager.GetComponent<gameManager>().winner;
        skins = Resources.LoadAll<Sprite>("UI/winMenu/winIcons");
        if(winner == 1)
        {
            pw = gameManager.GetComponent<gameManager>().p1skin;
        }else if (winner == 2)
        {
            pw = gameManager.GetComponent<gameManager>().p2skin;
        }
        else if (winner == 3)
        {
            pw = gameManager.GetComponent<gameManager>().p3skin;
        }
        else if (winner == 4)
        {
            pw = gameManager.GetComponent<gameManager>().p4skin;
        }
        
        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].name == pw.ToString())
            {
                imgp1 = skins[i];
                break;
            }
        }

        img.sprite = imgp1;

        if (GameObject.Find ("menuMusic")) {
			Destroy (GameObject.Find ("menuMusic"));
		}
		if (GameObject.Find ("gameMusic")) {
			Destroy (GameObject.Find ("gameMusic"));
		}

        setText();
        
    }
	
	void setText ()
    {
        p1.text = gameManager.GetComponent<gameManager>().p1Points.ToString("0");
        p2.text = gameManager.GetComponent<gameManager>().p2Points.ToString("0");
        p3.text = gameManager.GetComponent<gameManager>().p3Points.ToString("0");
        p4.text = gameManager.GetComponent<gameManager>().p4Points.ToString("0");
        rounds.text = gameManager.GetComponent<gameManager>().rounds.ToString("0");
        Destroy(gameManager);
    }
    
}
