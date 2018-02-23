using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartingGame : MonoBehaviour {

    public Button twoplayer;
	public Button threeplayer;
	public Button fourplayer;
	public Button start;

	public GameObject player1;
	public GameObject player2;
	public GameObject player3;
	public GameObject player4;

    public GameObject J1;
    public GameObject J2;
    public GameObject J3;
    public GameObject J4;

    public float QtyPlayers;
    private float PtsToWin = 300;
    public GameObject gameManager;

	public bool p1Active = false;
	public bool p2Active = false;
	public bool p3Active = false;
	public bool p4Active = false;

    public bool J1rdy = false;
    public bool J2rdy = false;
    public bool J3rdy = false;
    public bool J4rdy = false;

    private bool blinkon = false;
    private int cdblink = 0;

	// Use this for initialization
	void Start () {

        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        gameManager.GetComponent<gameManager>().pointsToWin = PtsToWin;

    }
	
	// Update is called once per frame
	void Update () {
        Effect();
            cdblink++;
        characters();

        if (J1rdy)
        {
            player1.SetActive(true);
        }
        if (J2rdy)
        {
            player2.SetActive(true);
        }
        if (J3rdy)
        {
            player3.SetActive(true);
        }
        if (J4rdy)
        {
            player4.SetActive(true);
        }

        GameObject textTemp = GameObject.Find("pointText");
        textTemp.GetComponent<Text>().text = "" + gameManager.GetComponent<gameManager>().pointsToWin;
		if (inputManager.Jump_p1 ()) {
			if (p1Active) {
                player1.SetActive (false);
				p1Active = false;
				QtyPlayers--;
			} else {
				p1Active = true;
				QtyPlayers++;
			}
		}
		if (inputManager.Jump_p2 ()) {
			if (p2Active) {
                player2.SetActive (false);
				p2Active = false;
				QtyPlayers--;
			} else {
                p2Active = true;
				QtyPlayers++;
			}
		}
		if (inputManager.Jump_p3 ()) {
			if (p3Active) {
                player3.SetActive (false);
				p3Active = false;
				QtyPlayers--;
			} else {
                p3Active = true;
				QtyPlayers++;
			}
		}
		if (inputManager.Jump_p4 ()) {
			if (p4Active) {
                player4.SetActive (false);
				p4Active = false;
				QtyPlayers--;
			} else {
                p4Active = true;
				QtyPlayers++;
			}
		}
	}


    public void characters()
    {
        if (p1Active)
        {
            if (J1.transform.position.y >= 1.5)
            {
                J1.transform.position -= new Vector3(0f, 0.5f, 0f);
                if (J1.transform.position.y == 1)
                {
                    J1rdy = true;
                }
            }
        }
        else
        {
            if (J1.transform.position.y <= 9.5)
            {
                J1.transform.position += new Vector3(0f, 0.5f, 0f);
                J1rdy = false;
            }
        }
        if (p2Active)
        {
            if (J2.transform.position.y >= 1.5)
            {
                J2.transform.position -= new Vector3(0f, 0.5f, 0f);
                if (J2.transform.position.y == 1)
                {
                    J2rdy = true;
                }
            }
        }
        else
        {
            if (J2.transform.position.y <= 9.5)
            {
                J2.transform.position += new Vector3(0f, 0.5f, 0f);
                J2rdy = false;
            }
        }
        if (p3Active)
        {
            if (J3.transform.position.y >= 1.5)
            {
                J3.transform.position -= new Vector3(0f, 0.5f, 0f);
                if (J3.transform.position.y == 1)
                {
                    J3rdy = true;
                }
            }
        }
        else
        {
            if (J3.transform.position.y <= 9.5)
            {
                J3.transform.position += new Vector3(0f, 0.5f, 0f);
                J3rdy = false;
            }
        }
        if (p4Active)
        {
            if (J4.transform.position.y >= 1.5)
            {
                J4.transform.position -= new Vector3(0f, 0.5f, 0f);
                if (J4.transform.position.y == 1)
                {
                    J4rdy = true;
                }
            }
        }
        else
        {
            if (J4.transform.position.y <= 9.5)
            {
                J4.transform.position += new Vector3(0f, 0.5f, 0f);
                J4rdy = false;
            }
        }
    }

    public void Effect()
    {
        if (blinkon == false)
        {
            player1.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
            player2.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
            player3.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
            player4.transform.localScale = new Vector3(1.2f, 1.2f, 1f);
            if (cdblink >= 10)
            {
                player1.transform.localScale = new Vector3(1f, 1f, 1f);
                player2.transform.localScale = new Vector3(1f, 1f, 1f);
                player3.transform.localScale = new Vector3(1f, 1f, 1f);
                player4.transform.localScale = new Vector3(1f, 1f, 1f);
                blinkon = true;
                
            }
        }else if (cdblink >= 20)
        {
            cdblink = 0;
            blinkon = false;
        }
    }

	public void BoutonStart ()
	{
        {
			if (QtyPlayers >= 2) {
				gameManager.GetComponent<gameManager> ().isPlaying = true;
				gameManager.GetComponent<gameManager> ().p1Active = p1Active;
				gameManager.GetComponent<gameManager> ().p2Active = p2Active;
				gameManager.GetComponent<gameManager> ().p3Active = p3Active;
				gameManager.GetComponent<gameManager> ().p4Active = p4Active;
				SceneManager.LoadScene ("game");
			}
        }
    }

}
