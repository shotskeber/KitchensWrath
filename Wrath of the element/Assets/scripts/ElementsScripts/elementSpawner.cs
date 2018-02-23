using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elementSpawner : MonoBehaviour {

	//Public Game Objects
	public GameObject[] players;
	public GameObject oilPrefab;
	public GameObject windPrefab;
	public GameObject meatPrefab;
	public GameObject firePrefab;
	public GameObject windAlertPrefab;
	public GameObject clone;
	public GameObject fxSounds;
	public GameObject tempWind;

	//public numbers
	public bool eventPlaying = false;
	public float timerDelays = 0;
	public float[] positions;
	public int posXWind;

	//Private variables
	private int eventType = 0;
	private float oldThing = 0;
	private float timeBetweenEvents = 5f;

	//Start Function
	void Start(){
		positions = new float[] {-24f, -19.9f, -3.7f, 9.3f, 19.9f, 24f}; 
		fxSounds = GameObject.FindGameObjectWithTag ("soundFx");
	}

	// Update is called once per frame
	void Update () {
		
		players = GameObject.FindGameObjectsWithTag("Player");

		if (timerDelays > timeBetweenEvents && !eventPlaying) {
			eventType = Random.Range (0, 3);
			if (oldThing != eventType) {
				if (eventType == 0) {
					eventPlaying = true;
					meatSpawn ();
					oldThing = eventType;
				} else if (eventType == 1) {
					eventPlaying = true;
					windSpawn ();
					oldThing = eventType;
				} else if (eventType == 2) {
					eventPlaying = true;
					fireSpawn ();
					oldThing = eventType;
				} else {
					print ("Error spawing element");
				}
			}
		} else {
			timerDelays += Time.deltaTime;
		}
		
	}
    

	void windSpawn(){
		tempWind = Instantiate (windAlertPrefab, new Vector3 (0f, 2.5f, 0f), Quaternion.identity);
		fxSounds.GetComponent<fxSounds> ().windStart ();
		Invoke ("spawnWindElement", 2f);
	}


	void spawnWindElement(){
		Destroy (tempWind);
		Instantiate (windPrefab, new Vector3 (0, 0, -9f), Quaternion.identity);
	}

    void meatSpawn()
    {
        clone = Instantiate(meatPrefab, new Vector3(0f, 30f, 0f), Quaternion.identity);

    }

	void fireSpawn()
	{
		clone = Instantiate(firePrefab, new Vector3(0f, 30f, 0f), Quaternion.identity);
	}
}
