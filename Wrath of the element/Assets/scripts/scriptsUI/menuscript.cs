using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Data;
using Mono.Data.Sqlite;

public class menuscript : MonoBehaviour
{
    //variables GO
    public GameObject affj1;
    public GameObject affj2;
    public GameObject affj3;
    public GameObject affj4;

    public GameObject join1;
    public GameObject join2;
    public GameObject join3;
    public GameObject join4;

    public GameObject readyj1;
    public GameObject readyj2;
    public GameObject readyj3;
    public GameObject readyj4;

    public GameObject confirmedj1;
    public GameObject confirmedj2;
    public GameObject confirmedj3;
    public GameObject confirmedj4;
    
    public GameObject gameManager;

    public GameObject Canvas;
    public GameObject Fond;
    public GameObject textTemp;

    //variables BOOL
    private bool j1Ok = false;
    private bool j2Ok = false;
    private bool j3Ok = false;
    private bool j4Ok = false;

    private bool P1 = false;
    private bool P2 = false;
    private bool P3 = false;
    private bool P4 = false;

    private bool j1conf = false;
    private bool j2conf = false;
    private bool j3conf = false;
    private bool j4conf = false;

    private bool p1val = true;
    private bool p2val = true;
    private bool p3val = true;
    private bool p4val = true;

    private bool p1cc = false;
    private bool p2cc = false;
    private bool p3cc = false;
    private bool p4cc = false;

    private bool inputactive = true;
    private bool pointselect = false;
    private bool points = false;

    private float cdpoint = 0f;

    private float cdpoint1 = 0f;
    private float cdpoint2 = 0f;
    private float cdpoint3 = 0f;
    private float cdpoint4 = 0f;
    private bool points1 = false;
    private bool points2 = false;
    private bool points3 = false;
    private bool points4 = false;


    public Sprite[] skins;
    public Sprite[] skins_locked;

    //variables
    public int qtyplayers = 0;
	public int qtyplayerok = 0;

    public float p1skin;
    public float p2skin;
    public float p3skin;
    public float p4skin;

    public float moveSpeed = 0.5f;
    public float yposFInal = 1.75f;

    public List<SkinProfile> skinStatus = new List<SkinProfile>();

    // Use this for initialization
    void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        skins = Resources.LoadAll<Sprite>("UI/NewSelectionmenu/unlocked");
        skins_locked = Resources.LoadAll<Sprite>("UI/NewSelectionmenu/locked");
        LoadSkins();
        setSkins();
    }
    // Update is called once per frame
    void Update()
    {
        cdpoint++;
        cdpoint1++;
        cdpoint2++;
        cdpoint3++;
        cdpoint4++;
        PlayGame();
        characters();
        skinChanger();

        

        if (cdpoint >= 12)
        {
            cdpoint = 12;
            if(cdpoint == 12)
            {
                points = true;
            }
        }
        if (cdpoint1 >= 12)
        {
            cdpoint1 = 12;
            if (cdpoint1 == 12)
            {
                points1 = true;
            }
        }
        if (cdpoint2 >= 12)
        {
            cdpoint2 = 12;
            if (cdpoint2 == 12)
            {
                points2 = true;
            }
        }
        if (cdpoint3 >= 12)
        {
            cdpoint3 = 12;
            if (cdpoint3 == 12)
            {
                points3 = true;
            }
        }
        if (cdpoint4 >= 12)
        {
            cdpoint4 = 12;
            if (cdpoint4 == 12)
            {
                points4 = true;
            }
        }

        if (inputManager.Cancel())
        {
            if (pointselect)
            {
                SceneManager.LoadScene("selection_menu");
            }
            else if(j1Ok == false && j2Ok == false && j3Ok == false && j4Ok == false)
            {
                SceneManager.LoadScene("main_menu");
            }

        }

        if (inputManager.Submit())
        {
            if (pointselect)
            {
                SceneManager.LoadScene("game");
            }
        }

        if (inputManager.Horizontal() == 1)
        {
            if (pointselect)
            {
                if (gameManager.GetComponent<gameManager>().pointsToWin <= 300)
                {
                    if (points == true)
                    {
                        gameManager.GetComponent<gameManager>().pointsToWin += 50;
                        points = false;
                        cdpoint = 0;
                    }
                    if (gameManager.GetComponent<gameManager>().pointsToWin == 350)
                    {
                        gameManager.GetComponent<gameManager>().pointsToWin = 50;
                    }
                }
            }
        }

        if (inputManager.Horizontal() == -1)
        {
            if (pointselect)
            {
                if (gameManager.GetComponent<gameManager>().pointsToWin >= 0)
                {
                    if (points == true)
                    {
                        gameManager.GetComponent<gameManager>().pointsToWin -= 50;
                        points = false;
                        cdpoint = 0;
                    }
                    if (gameManager.GetComponent<gameManager>().pointsToWin == 0)
                    {
                        gameManager.GetComponent<gameManager>().pointsToWin = 300;
                    }
                }
            }
        }

        if (inputactive == true)
        {

        if (inputManager.Jump_p1())
        {
            setSkins();
            if (j1Ok == true && p1val)
            {
					if (!j1conf) {
                        p1cc = false;
                        confirmedj1.SetActive (true);
						readyj1.SetActive (false);
						j1conf = true;
						qtyplayerok++;
					}
            }
            else
            {

                p1cc = true;
				join1.SetActive (false);
				readyj1.SetActive (true);
                    
                    if (!j1Ok)
                    {
                        qtyplayers++;
                    }
                    j1Ok = true;
				
            }
        }
        if (inputManager.Jump_p2())
        {
            setSkins();
            if (j2Ok == true && p2val)
            {
					if (!j2conf) {
                        p2cc = false;
                        confirmedj2.SetActive (true);
						readyj2.SetActive (false);
						j2conf = true;
						qtyplayerok++;
					}
            }
            else
            {
                    p2cc = true;
                    join2.SetActive (false);
				readyj2.SetActive (true);
                    if (!j2Ok)
                    {
                        qtyplayers++;
                    }
                    j2Ok = true;
            }
        }
        if (inputManager.Jump_p3() )
        {
            setSkins();
            if (j3Ok == true && p3val)
            {
					if (!j3conf) {
                        p3cc = false;
                        confirmedj3.SetActive (true);
						readyj3.SetActive (false);
						j3conf = true;
						qtyplayerok++;
					}
            }
            else
            {
                    p3cc = true;
                    join3.SetActive (false);
				readyj3.SetActive (true);
                    if (!j3Ok)
                    {
                        qtyplayers++;
                    }
                    j3Ok = true;
            }
        }
        if (inputManager.Jump_p4())
        {
            setSkins();
            if (j4Ok == true && p4val)
            {
					if (!j4conf) {
                        p4cc = false;
                        confirmedj4.SetActive (true);
						readyj4.SetActive (false);
						j4conf = true;
						qtyplayerok++;
					}
            }
            else
            {
                    p4cc = true;
                    join4.SetActive (false);
				readyj4.SetActive (true);
                    if (!j4Ok)
                    {
                        qtyplayers++;
                    }
                    j4Ok = true;
            }
        }

        if (inputManager.Dash_p1())
        {
            if (j1Ok && j1conf == false)
            {
                j1Ok = false;
                readyj1.SetActive(false);
                join1.SetActive(true);
                qtyplayers--;
                    p1cc = false;
            }
            if (j1conf)
            {
                j1conf = false;
                readyj1.SetActive(true);
                confirmedj1.SetActive(false);
                qtyplayerok--;
                    p1cc = true;
                }
        }

        if (inputManager.Dash_p2())
        {
            if (j2Ok && j2conf == false)
            {
                j2Ok = false;
                readyj2.SetActive(false);
                join2.SetActive(true);
                qtyplayers--;
                    p2cc = false;
                }
            if (j2conf)
            {
                j2conf = false;
                readyj2.SetActive(true);
                confirmedj2.SetActive(false);
                qtyplayerok--;
                    p2cc = true;
                }
        }

        if (inputManager.Dash_p3())
        {
            if (j3Ok && j3conf == false)
            {
                j3Ok = false;
                readyj3.SetActive(false);
                join3.SetActive(true);
                qtyplayers--;
                    p3cc = false;
                }
            if (j3conf)
            {
                j3conf = false;
                readyj3.SetActive(true);
                confirmedj3.SetActive(false);
                qtyplayerok--;
                    p3cc = true;
                }
        }

        if (inputManager.Dash_p4())
        {
            if (j4Ok && j4conf == false)
            {
                j4Ok = false;
                readyj4.SetActive(false);
                join4.SetActive(true);
                qtyplayers--;
                    p4cc = false;
                }
            if (j4conf)
            {
                j4conf = false;
                readyj4.SetActive(true);
                confirmedj4.SetActive(false);
                qtyplayerok--;
                    p4cc = true;
                }
        }
        }
    }

    public void PlayGame()
    {
        if (qtyplayers > 1)
        {
            if (qtyplayers == qtyplayerok)
            {
                inputactive = false;
                gameManager.GetComponent<gameManager>().isPlaying = true;
                gameManager.GetComponent<gameManager>().p1Active = j1conf;
                gameManager.GetComponent<gameManager>().p2Active = j2conf;
                gameManager.GetComponent<gameManager>().p3Active = j3conf;
                gameManager.GetComponent<gameManager>().p4Active = j4conf;
                
                        Canvas.SetActive(true);
                        pointselect = true;

                textTemp = GameObject.Find("PointText");
				if (textTemp != null) {
					textTemp.GetComponent<Text> ().text = "" + gameManager.GetComponent<gameManager> ().pointsToWin;
				}
            }
        }
    }

    public void characters()
    {
        if (j1Ok)
        {
            if (affj1.transform.position.y >= yposFInal)
            {
                affj1.transform.position -= new Vector3(0f, moveSpeed, 0f);
                if (affj1.transform.position.y == 0.5f)
                {
                    P1 = true;
                }
            }
        }
        else
        {
            if (affj1.transform.position.y <= 11.28f)
            {
                affj1.transform.position += new Vector3(0f, moveSpeed, 0f);
                j1Ok = false;
            }
        }
        if (j2Ok)
        {
            if (affj2.transform.position.y >= yposFInal)
            {
                affj2.transform.position -= new Vector3(0f, moveSpeed, 0f);
                if (affj2.transform.position.y == 0.5f)
                {
                    P2 = true;
                }
            }
        }
        else
        {
            if (affj2.transform.position.y <= 11.28f)
            {
                affj2.transform.position += new Vector3(0f, moveSpeed, 0f);
                j2Ok = false;
            }
        }
        if (j3Ok)
        {
            if (affj3.transform.position.y >= yposFInal)
            {
                affj3.transform.position -= new Vector3(0f, moveSpeed, 0f);
                if (affj3.transform.position.y == 0.5f)
                {
                    P3 = true;
                }
            }
        }
        else
        {
            if (affj3.transform.position.y <= 11.28f)
            {
                affj3.transform.position += new Vector3(0f, moveSpeed, 0f);
                j3Ok = false;
            }
        }
        if (j4Ok)
        {
            if (affj4.transform.position.y >= yposFInal)
            {
                affj4.transform.position -= new Vector3(0f, moveSpeed, 0f);
                if (affj4.transform.position.y == 0.5f)
                {
                    P4 = true;
                }
            }
        }
        else
        {
            if (affj4.transform.position.y <= 11.28f)
            {
                affj4.transform.position += new Vector3(0f, moveSpeed, 0f);
                j4Ok = false;
            }
        }
    }
    void setSkins()
    {
        p1skin = gameManager.GetComponent<gameManager>().p1skin;
        p2skin = gameManager.GetComponent<gameManager>().p2skin;
        p3skin = gameManager.GetComponent<gameManager>().p3skin;
        p4skin = gameManager.GetComponent<gameManager>().p4skin;

        if (lockCheck(p1skin) == false)
        {
            p1val = true;
            for (int i = 0; i < skins.Length; i++)
            {
                if (skins[i].name == p1skin.ToString())
                {
                    affj1.GetComponent<SpriteRenderer>().sprite = skins[i];
                    break;
                }
            }
        }
        else
        {
            p1val = false;
            for (int i = 0; i < skins_locked.Length; i++)
            {
                if (skins_locked[i].name == p1skin.ToString())
                {
                    affj1.GetComponent<SpriteRenderer>().sprite = skins_locked[i];
                    break;
                }
            }
        }



        if (lockCheck(p2skin) == false)
        {
            p2val = true;
            for (int i = 0; i < skins.Length; i++)
            {
                if (skins[i].name == p2skin.ToString())
                {
                    affj2.GetComponent<SpriteRenderer>().sprite = skins[i];
                    break;
                }
            }
        }
        else
        {
            p2val = false;
            for (int i = 0; i < skins_locked.Length; i++)
            {
                if (skins_locked[i].name == p2skin.ToString())
                {
                    affj2.GetComponent<SpriteRenderer>().sprite = skins_locked[i];
                    break;
                }
            }
        }


        if (lockCheck(p3skin) == false)
        {
            p3val = true;
            for (int i = 0; i < skins.Length; i++)
            {
                if (skins[i].name == p3skin.ToString())
                {
                    affj3.GetComponent<SpriteRenderer>().sprite = skins[i];
                    break;
                }
            }
        }
        else
        {
            p3val = false;
            for (int i = 0; i < skins_locked.Length; i++)
            {
                if (skins_locked[i].name == p3skin.ToString())
                {
                    affj3.GetComponent<SpriteRenderer>().sprite = skins_locked[i];
                    break;
                }
            }
        }


        if (lockCheck(p4skin) == false)
        {
            p4val = true;
            for (int i = 0; i < skins.Length; i++)
            {
                if (skins[i].name == p4skin.ToString())
                {
                    affj4.GetComponent<SpriteRenderer>().sprite = skins[i];
                    break;
                }
            }
        }
        else
        {
            p4val = false;
            for (int i = 0; i < skins_locked.Length; i++)
            {
                if (skins_locked[i].name == p4skin.ToString())
                {
                    affj4.GetComponent<SpriteRenderer>().sprite = skins_locked[i];
                    break;
                }
            }
        }


    }
    bool lockCheck(float id)
    {
        bool islocked = true;
        foreach (SkinProfile i in skinStatus)
        {
            if(i.idSkin == id)
            {
                if(i.unlocked == 1)
                {
                    islocked = false;
                    break;
                }
                else
                {
                    islocked = true;
                    break;
                }
            }
        }
        return islocked;
    }
    List<SkinProfile> LoadSkins()
    {
        skinStatus.Clear();
        var command = @"SELECT * FROM skins ORDER BY idSkin";
        var profile = new SkinProfile();

        using (var dbConnection = new SqliteConnection("URI=file:" + Application.dataPath + "/StreamingAssets/main.db"))
        {
            using (var dbCommand = dbConnection.CreateCommand())
            {
                dbConnection.Open();

                dbCommand.CommandText = command;

                using (var dbReader = dbCommand.ExecuteReader())
                {
                    while (dbReader.Read())
                    {
                        if (dbReader.GetValue(0) != null)
                        {
                            var skin = new SkinProfile();
                            skin.idSkin = dbReader.GetInt32(0);
                            skin.unlocked = dbReader.GetInt32(3);

                            skinStatus.Add(skin);
                        }
                    }
                }
            }
        }
        return skinStatus;
    }
    void skinChanger()
    {
        if (inputManager.Move_p1() == 1 && points1 && p1cc)
        {
            if ((gameManager.GetComponent<gameManager>().p1skin + 1) > 24)
            {
                gameManager.GetComponent<gameManager>().p1skin = 1;
            }
            else
            {
                gameManager.GetComponent<gameManager>().p1skin++;
            }
            points1 = false;
            cdpoint1 = 0;
            setSkins();

        }
        if (inputManager.Move_p1() == -1 && points1 && p1cc)
        {
            if ((gameManager.GetComponent<gameManager>().p1skin - 1) < 1)
            {
                gameManager.GetComponent<gameManager>().p1skin = 24;
            }
            else
            {
                gameManager.GetComponent<gameManager>().p1skin--;
            }
            points1 = false;
            cdpoint1 = 0;
            setSkins();

        }

        if (inputManager.Move_p2() == 1 && points2 && p2cc)
        {

            if ((gameManager.GetComponent<gameManager>().p2skin + 1) > 24)
            {
                gameManager.GetComponent<gameManager>().p2skin = 1;
            }
            else
            {
                gameManager.GetComponent<gameManager>().p2skin++;
            }
            points2 = false;
            cdpoint2 = 0;
            setSkins();

        }
        if (inputManager.Move_p2() == -1 && points2 && p2cc)
        {

            if ((gameManager.GetComponent<gameManager>().p2skin - 1) < 1)
            {
                gameManager.GetComponent<gameManager>().p2skin = 24;
            }
            else
            {
                gameManager.GetComponent<gameManager>().p2skin--;
            }
            points2 = false;
            cdpoint2 = 0;
            setSkins();

        }

        if (inputManager.Move_p3() == 1 && points3 && p3cc)
        {

            if ((gameManager.GetComponent<gameManager>().p3skin + 1) > 24)
            {
                gameManager.GetComponent<gameManager>().p3skin = 1;
            }
            else
            {
                gameManager.GetComponent<gameManager>().p3skin++;
            }
            points3 = false;
            cdpoint3 = 0;
            setSkins();

        }
        if (inputManager.Move_p3() == -1 && points3 && p3cc)
        {

            if ((gameManager.GetComponent<gameManager>().p3skin - 1) < 1)
            {
                gameManager.GetComponent<gameManager>().p3skin = 24;
            }
            else
            {
                gameManager.GetComponent<gameManager>().p3skin--;
            }
            points3 = false;
            cdpoint3 = 0;
            setSkins();

        }

        if (inputManager.Move_p4() == 1 && points4 && p4cc)
        {

            if ((gameManager.GetComponent<gameManager>().p4skin + 1) > 24)
            {
                gameManager.GetComponent<gameManager>().p4skin = 1;
            }
            else
            {
                gameManager.GetComponent<gameManager>().p4skin++;
            }
            points4 = false;
            cdpoint4 = 0;
            setSkins();

        }
        if (inputManager.Move_p4() == -1 && points4 && p4cc)
        {

            if ((gameManager.GetComponent<gameManager>().p4skin - 1) < 1)
            {
                gameManager.GetComponent<gameManager>().p4skin = 24;
            }
            else
            {
                gameManager.GetComponent<gameManager>().p4skin--;
            }
            points4 = false;
            cdpoint4 = 0;
            setSkins();

        }
    }

}
