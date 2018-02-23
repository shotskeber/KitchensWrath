 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class windScript : MonoBehaviour {

	public GameObject gameStateObj;
	public GameObject[] players;
	public GameObject testPlatform;
	public GameObject gameManager;

	public float eventDuration = 7f;
	public float difficulty = 1f;

	private bool invertedGrav = false;
	private float timerReal = 0f;

	// Update is called once per frame
	void Start(){
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		gameStateObj = GameObject.FindGameObjectWithTag ("gameState");
		players = GameObject.FindGameObjectsWithTag ("Player");

	}

	void Update () {
		players = GameObject.FindGameObjectsWithTag ("Player");
		if (timerReal > eventDuration) {
			gameStateObj.GetComponent<elementSpawner> ().eventPlaying = false;
			gameStateObj.GetComponent<elementSpawner> ().timerDelays = 0f;
			for (int i = 0; i < players.Length; i++) {
				Transform tempScale = players [i].GetComponent<Transform> ();
				players [i].GetComponent<Rigidbody2D> ().gravityScale = 9.8f;
				players [i].GetComponent<Transform> ().localScale = new Vector3(tempScale.localScale.x * -1, tempScale.localScale.y * -1, tempScale.localScale.z);
			}
			Destroy (gameObject);
		} else {
			if (!invertedGrav) {
				invertedGrav = true;
				for (int i = 0; i < players.Length; i++) {
						Transform tempScale = players [i].GetComponent<Transform> ();
						players [i].GetComponent<Rigidbody2D> ().gravityScale = -9.8f;
						players [i].GetComponent<Transform>().localScale = new Vector3(tempScale.localScale.x*-1, tempScale.localScale.y*-1,tempScale.localScale.z);
				}
			}
		}

		if (timerReal < eventDuration) {
			timerReal += Time.deltaTime;
		}
	}
}