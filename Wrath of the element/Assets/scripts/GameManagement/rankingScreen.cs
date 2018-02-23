using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rankingScreen : MonoBehaviour {

	public GameObject gameManager;
	private bool p1actives;
	private bool p2actives;
	private bool p3actives;
	private bool p4actives;

	public GameObject Player1;
	public GameObject Player2;
	public GameObject Player3;
	public GameObject Player4;
	public GameObject Player1plat;
	public GameObject Player2plat;
	public GameObject Player3plat;
	public GameObject Player4plat;
    SQLstats sqlStats;

    // Use this for initialization
    void Start () {
		gameManager = GameObject.FindGameObjectWithTag ("GameManager");
		p1actives = gameManager.GetComponent<gameManager>().p1Active;
		p2actives = gameManager.GetComponent<gameManager>().p2Active;
		p3actives = gameManager.GetComponent<gameManager>().p3Active;
		p4actives = gameManager.GetComponent<gameManager>().p4Active;
        sqlStats = GameObject.Find("sqlStats").GetComponent<SQLstats>();
        

		if (p1actives == true)
		{
			Player1.SetActive(true);
			Player1plat.SetActive (true);
			float points = gameManager.GetComponent<gameManager> ().p1Points;
			StartCoroutine (scale (points, Player1plat));
            if (gameManager.GetComponent<gameManager>().gameOver)
            {
                sqlStats.addGame(1);
            }
        }
		if (p2actives == true)
		{
			Player2.SetActive(true);
			Player2plat.SetActive (true);
			float points = gameManager.GetComponent<gameManager> ().p2Points;
			StartCoroutine (scale (points, Player2plat));
            if (gameManager.GetComponent<gameManager>().gameOver)
            {
                sqlStats.addGame(2);
            }
        }
		if (p3actives == true)
		{
			Player3.SetActive(true);
			Player3plat.SetActive (true);
			float points = gameManager.GetComponent<gameManager> ().p3Points;
			StartCoroutine (scale (points, Player3plat));
            if (gameManager.GetComponent<gameManager>().gameOver)
            {
                sqlStats.addGame(3);
            }
        }
		if (p4actives == true)
		{
			Player4.SetActive(true);
			Player4plat.SetActive (true);
			float points = gameManager.GetComponent<gameManager> ().p4Points;
			StartCoroutine (scale (points, Player4plat));
            if (gameManager.GetComponent<gameManager>().gameOver)
            {
                sqlStats.addGame(4);
            }
        }
		Invoke ("gameReload", 5f);
	}
	
	// Update is called once per frame
	void Update () {
	}

	IEnumerator scale(float finalyscore, GameObject platform){
        Vector3 originalPos = platform.transform.position;
		finalyscore = finalyscore * (6.23f/gameManager.GetComponent<gameManager>().pointsToWin);
        Vector3 temp = new Vector3(originalPos.x, finalyscore-4.47f, originalPos.z);
			float currentTime = 0.0f;

			do
			{
			    platform.transform.position = Vector3.Lerp(originalPos, temp, currentTime / 3);
				currentTime += Time.deltaTime;
				yield return null;
		    } while (currentTime <= 3);

			
		    }
	void gameReload(){
        //SceneManager.LoadScene("game");
		if (gameManager.GetComponent<gameManager> ().gameOver) {
            SceneManager.LoadScene ("WinScene");
		} else {
			int temp = Random.Range (1, 3);
			print (temp + "level");
			SceneManager.LoadScene ("game");
		}
	}
}
