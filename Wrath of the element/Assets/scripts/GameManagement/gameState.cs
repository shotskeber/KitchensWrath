using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameState : MonoBehaviour {

	public GameObject[] players;
	public float zoomSpeed = 1;
	public float targetOrtho;
	public float smoothSpeed = 15.0f;
	public Camera gameCam;
	public GameObject gameManager;
	public GameObject lastPlayer;
	public bool isInvoking = false;
	public bool wonLevel = false;
	public gameManager gm;
    public GameObject timerstart;
    private GameObject timetostart;
    private SQLstats sqlStats;


    public GameObject UIpause;
    private bool pause = false;

	void Start() {
        sqlStats = GameObject.Find("sqlStats").GetComponent<SQLstats>();
        targetOrtho = Camera.main.orthographicSize;
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		gm = gameManager.GetComponent<gameManager> ();
		Cursor.visible = false;
	}

	void Update () {

		players = GameObject.FindGameObjectsWithTag("Player");
		/*foreach (GameObject player in players) {
			print(players.Length);
		}*/
		if (GameObject.Find ("char1p") != null) {
			GameObject.Find ("char1p").gameObject.GetComponent<Text> ().text = gameManager.GetComponent<gameManager> ().p1Points.ToString("0");
		}
		if (GameObject.Find ("char2p") != null) {
			GameObject.Find ("char2p").gameObject.GetComponent<Text> ().text = gameManager.GetComponent<gameManager> ().p2Points.ToString("0");
		}
		if (GameObject.Find ("char3p") != null) {
			GameObject.Find ("char3p").gameObject.GetComponent<Text> ().text = gameManager.GetComponent<gameManager> ().p3Points.ToString("0");
		}
		if (GameObject.Find ("char4p") != null) {
			GameObject.Find ("char4p").gameObject.GetComponent<Text> ().text = gameManager.GetComponent<gameManager> ().p4Points.ToString("0");
		}
		if (players.Length == 1) {
			wonLevel = true;
			gameCam.GetComponent<camShake> ().shakeEnabled = false;
			Time.timeScale = 0.25F;
			targetOrtho = 5;
			Camera.main.orthographicSize = Mathf.MoveTowards (Camera.main.orthographicSize, targetOrtho, smoothSpeed / 2 * Time.deltaTime);
			lastPlayer = GameObject.FindGameObjectWithTag ("Player");
			float xpos = Mathf.MoveTowards (gameCam.transform.position.x, lastPlayer.transform.position.x, smoothSpeed * Time.deltaTime);
			float ypos = Mathf.MoveTowards (gameCam.transform.position.y, lastPlayer.transform.position.y, smoothSpeed * Time.deltaTime);
			gameCam.transform.position = new Vector3 (xpos, ypos, -20f);
			//Despawn elements
			if (isInvoking == false) {
				isInvoking = true;
				if (lastPlayer.name == "player1") {
                    sqlStats.addMatch(1);
                    if (gm.p1Points +10 < gm.pointsToWin) {
						gm.p1Points += 10;
					} else {
						gm.p1Points += gm.pointsToWin - gm.p1Points;
					}
				} else if (lastPlayer.name == "player2") {
                    sqlStats.addMatch(2);
                    if (gm.p2Points +10 < gm.pointsToWin) {
						gm.p2Points += 10;
					} else {
						gm.p2Points += gm.pointsToWin - gm.p2Points;
					}
				} else if (lastPlayer.name == "player3") {
                    sqlStats.addMatch(3);
                    if (gm.p3Points +10 < gm.pointsToWin) {
						gm.p3Points += 10;
					} else {
						gm.p3Points += gm.pointsToWin - gm.p3Points;
					}
				} else if (lastPlayer.name == "player4") {
                    sqlStats.addMatch(4);
                    if (gm.p4Points +10 < gm.pointsToWin) {
						gm.p4Points += 10;
					} else {
						gm.p4Points += gm.pointsToWin - gm.p4Points;
					}
				} 
				Invoke ("nextScene", 0.5f);
			}
		} else if (players.Length == 0) {
			Invoke ("nextScene", 0.5f);
		}

        if (timerstart.GetComponent<timerstart>().startup == true)
        {
            if (inputManager.Pause())
            {
                if (pause == false)
                {
                    UIpause.SetActive(true);
                    Time.timeScale = 0F;
                    Cursor.visible = true;
                    pause = true;
                }
                else
                {
                    UIpause.SetActive(false);
                    Time.timeScale = 1F;
                    Cursor.visible = false;
                    pause = false;
                }
            }
        }
    }


	void nextScene(){
		Time.timeScale = 1F;
        gameManager.GetComponent<gameManager>().rounds += 1;
        if (gameManager.GetComponent<gameManager> ().gameOver) {
			SceneManager.LoadScene ("betweenGame");
		} else {
			SceneManager.LoadScene ("betweenGame");
		}
	}

}
