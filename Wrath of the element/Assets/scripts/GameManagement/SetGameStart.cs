using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGameStart : MonoBehaviour
{
    //variables

    public GameObject Player1;
    public GameObject Player2;
    public GameObject Player3;
    public GameObject Player4;

    private bool p1actives;
    private bool p2actives;
    private bool p3actives;
    private bool p4actives;

	public GameObject char1p;
	public GameObject char2p;
	public GameObject char3p;
	public GameObject char4p;

	public GameObject char1img;
	public GameObject char2img;
	public GameObject char3img;
	public GameObject char4img;

    public GameObject fond1;
    public GameObject fond2;
    public GameObject fond3;
    public GameObject fond4;

    public GameObject gameManager;

    public float p1skin;
    public float p2skin;
    public float p3skin;
    public float p4skin;
    public Sprite[] skins;
    
    void Start ()

    {
        skins = Resources.LoadAll<Sprite>("sprite_sheet");

        gameManager = GameObject.FindGameObjectWithTag("GameManager");

        p1actives = gameManager.GetComponent<gameManager>().p1Active;
        p2actives = gameManager.GetComponent<gameManager>().p2Active;
        p3actives = gameManager.GetComponent<gameManager>().p3Active;
        p4actives = gameManager.GetComponent<gameManager>().p4Active;

        p1skin = gameManager.GetComponent<gameManager>().p1skin;
        p2skin = gameManager.GetComponent<gameManager>().p2skin;
        p3skin = gameManager.GetComponent<gameManager>().p3skin;
        p4skin = gameManager.GetComponent<gameManager>().p4skin;

        if (p1actives == true)
        {
            Player1.SetActive(true);
			char1p.SetActive (true);
			char1img.SetActive (true);
            fond1.SetActive(true);
            var tempFound = false;
            var corps = Player1.GetComponent<Transform>().Find("corps").GetComponent<Transform>();
            for (int i = 0; i < skins.Length; i++)
            {
                if (skins[i].name == p1skin + "_open")
                {
                    corps.Find("eyes_open").GetComponent<SpriteRenderer>().sprite = skins[i];
                }
                if (skins[i].name == p1skin + "_close")
                {
                    tempFound = true;
                    corps.Find("eyes_close").GetComponent<SpriteRenderer>().sprite = skins[i];
                }
            }
            if (!tempFound)
            {
                corps.Find("eyes_close").GetComponent<SpriteRenderer>().sprite = corps.Find("eyes_open").GetComponent<SpriteRenderer>().sprite;
            }
        }
        if (p2actives == true)
        {
			Player2.SetActive(true);
			char2p.SetActive (true);
			char2img.SetActive (true);
            fond2.SetActive(true);
            var tempFound = false;
            var corps2 = Player2.GetComponent<Transform>().Find("corps").GetComponent<Transform>();
            for (int i = 0; i < skins.Length; i++)
            {
                if (skins[i].name == p2skin + "_open")
                {
                    corps2.Find("eyes_open").GetComponent<SpriteRenderer>().sprite = skins[i];
                }
                if (skins[i].name == p2skin + "_close")
                {
                    tempFound = true;
                    corps2.Find("eyes_close").GetComponent<SpriteRenderer>().sprite = skins[i];
                }
            }
            if (!tempFound)
            {
                corps2.Find("eyes_close").GetComponent<SpriteRenderer>().sprite = corps2.Find("eyes_open").GetComponent<SpriteRenderer>().sprite;
            }
        }
        if (p3actives == true)
        {
			Player3.SetActive(true);
			char3p.SetActive (true);
			char3img.SetActive (true);
            fond3.SetActive(true);
            var tempFound = false;
            var corps3 = Player3.GetComponent<Transform>().Find("corps").GetComponent<Transform>();
            for (int i = 0; i < skins.Length; i++)
            {
                if (skins[i].name == p3skin + "_open")
                {
                    corps3.Find("eyes_open").GetComponent<SpriteRenderer>().sprite = skins[i];
                }
                if (skins[i].name == p3skin + "_close")
                {
                    tempFound = true;
                    corps3.Find("eyes_close").GetComponent<SpriteRenderer>().sprite = skins[i];
                }
            }
            if (!tempFound)
            {
                corps3.Find("eyes_close").GetComponent<SpriteRenderer>().sprite = corps3.Find("eyes_open").GetComponent<SpriteRenderer>().sprite;
            }
        }
        if (p4actives == true)
        {
			Player4.SetActive(true);
			char4p.SetActive (true);
			char4img.SetActive (true);
            fond4.SetActive(true);
            var tempFound = false;
            var corps4 = Player4.GetComponent<Transform>().Find("corps").GetComponent<Transform>();
            for (int i = 0; i < skins.Length; i++)
            {
                if (skins[i].name == p4skin + "_open")
                {
                    corps4.Find("eyes_open").GetComponent<SpriteRenderer>().sprite = skins[i];
                }
                if (skins[i].name == p4skin + "_close")
                {
                    tempFound = true;
                    corps4.Find("eyes_close").GetComponent<SpriteRenderer>().sprite = skins[i];
                }
            }
            if (!tempFound)
            {
                corps4.Find("eyes_close").GetComponent<SpriteRenderer>().sprite = corps4.Find("eyes_open").GetComponent<SpriteRenderer>().sprite;
            }
        }
    }


}
