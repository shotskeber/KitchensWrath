using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDswitch : MonoBehaviour
{
    //variables 

    public GameObject gameManager;

    public Sprite imgp1;
    public Sprite imgp2;
    public Sprite imgp3;
    public Sprite imgp4;

    private float p1;
    private float p2;
    private float p3;
    private float p4;

    public Sprite[] skins;

    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        skins = Resources.LoadAll<Sprite>("UI/HUD/HUDicons");

        p1 = gameManager.GetComponent<gameManager>().p1skin;
        p2 = gameManager.GetComponent<gameManager>().p2skin;
        p3 = gameManager.GetComponent<gameManager>().p3skin;
        p4 = gameManager.GetComponent<gameManager>().p4skin;

        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].name == p1.ToString())
            {
                imgp1 = skins[i];
                break;
            }
        }
        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].name == p2.ToString())
            {
                imgp2 = skins[i];
                break;
            }
        }
        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].name == p3.ToString())
            {
                imgp3 = skins[i];
                break;
            }
        }
        for (int i = 0; i < skins.Length; i++)
        {
            if (skins[i].name == p4.ToString())
            {
                imgp4 = skins[i];
                break;
            }
        }

        gameObject.GetComponent<RectTransform>().Find("player1img").GetComponent<Image>().sprite = imgp1;
        gameObject.GetComponent<RectTransform>().Find("player2img").GetComponent<Image>().sprite = imgp2;
        gameObject.GetComponent<RectTransform>().Find("player3img").GetComponent<Image>().sprite = imgp3;
        gameObject.GetComponent<RectTransform>().Find("player4img").GetComponent<Image>().sprite = imgp4;
    }
	
	void Update ()
    {
		
	}
}
