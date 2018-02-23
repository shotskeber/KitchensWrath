using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class fireScript : MonoBehaviour {

	public float eventDuration = 2f;
	public float difficulty = 1f;
	public GameObject gameStateObj;
	public GameObject[] platforms;
	public List<GameObject> changePlat = new List<GameObject>();
	public GameObject firePrefab;
	public GameObject oldWok;
	public GameObject[] players;
	public GameObject gameManager;

	private float timerReal = 0f;
	private float deathFire = 0;
	private float aliveFirst = 0f;

    public GameObject fireWok;
    public GameObject tempFire;

	// Update is called once per frame
	void Start(){
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		gameStateObj = GameObject.FindGameObjectWithTag ("gameState");
		players = GameObject.FindGameObjectsWithTag ("Player");
		aliveFirst = players.Length;
        tempFire = Instantiate(fireWok, new Vector3(-0.26f, -2.88f, 0), Quaternion.identity);
		for (int i = 0; i < 12; i++) {
			platforms = GameObject.FindGameObjectsWithTag ("floor");
			int rnd = Random.Range (0, platforms.Length);
            platforms[rnd].GetComponent<Transform>().Find("preFire").gameObject.SetActive(true);
			changePlat.Add(platforms [rnd]);
		}
		//oldWok = GameObject.FindGameObjectWithTag ("wokplatform");
		//GameObject.FindGameObjectWithTag ("wokplatform").GetComponent<SpriteRenderer> ().color = new Color (255f, 0f, 0f);
		Invoke ("turnRed", 2f);
	}

	void Update () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		if(timerReal > eventDuration){
			gameStateObj.GetComponent<elementSpawner> ().eventPlaying = false;
			gameStateObj.GetComponent<elementSpawner> ().timerDelays = 0f;
            Destroy(tempFire);
			deathFire = aliveFirst - players.Length;
			if (aliveFirst != 0) {
				float temp = ((aliveFirst - players.Length) / aliveFirst);
				if (temp > 0.8f) {
					temp = 1;
				} else if (temp > 0.6f) {
					temp = 2;
				} else if (temp > 0.4f) {
					temp = 3;
				} else if (temp > 0.2f) {
					temp = 4;
				} else {
					temp = 5;
				} 
				gameManager.GetComponent<gameManager> ().fireDiff = temp;
			}
			for (int i = 0; i < changePlat.Count; i++) {
				changePlat [i].tag = "floor";
                changePlat[i].GetComponent<Transform>().Find("preFire").gameObject.SetActive(false);
                changePlat[i].GetComponent<Transform>().Find("fireFx").gameObject.SetActive(false);
			}
			for (int i = 0; i < players.Length; i++) {
				if (players[i].GetComponent<moveplayer>() != null)
				{
					players [i].GetComponent<moveplayer> ().burnOver ();
				}
				else if (players[i].GetComponent<moveplayer2>() != null)
				{
					players[i].GetComponent<moveplayer2>().burnOver ();
				}
				else if (players[i].GetComponent<moveplayer3>() != null)
				{
					players[i].GetComponent<moveplayer3>().burnOver ();
				}
				else if (players[i].GetComponent<moveplayer4>() != null)
				{
					players[i].GetComponent<moveplayer4>().burnOver ();
				}
			}
			Destroy (gameObject);
		}

		if (timerReal < eventDuration) {
			timerReal += Time.deltaTime;
		}
	}

	void turnRed(){
		GameObject clone;
		players = GameObject.FindGameObjectsWithTag ("Player");
		for (int i = 0; i < players.Length; i++) {
			players [i].GetComponent<BoxCollider2D> ().enabled = false;
		}
		for (int i = 0; i < changePlat.Count; i++) {
			changePlat [i].tag = "fire";
            changePlat[i].GetComponent<Transform>().Find("preFire").gameObject.SetActive(false);
            changePlat[i].GetComponent<Transform>().Find("fireFx").gameObject.SetActive(true);
		}
		for (int i = 0; i < players.Length; i++) {
			players [i].GetComponent<BoxCollider2D> ().enabled = true;
		}
		//GameObject.FindGameObjectWithTag ("wokplatform").tag = "fire";
	}
}
