using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inGameMusic : MonoBehaviour {
	
	public static inGameMusic gameMusic = null;  

	// Use this for initialization
	void Start () {
		if (gameMusic == null) {
			//if not, set instance to this
			gameMusic = this;
			//If instance already exists and it's not this:
		} else if (gameMusic != this) {
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    
		}
		if (GameObject.Find ("menuMusic")) {
			Destroy (GameObject.Find ("menuMusic"));
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
