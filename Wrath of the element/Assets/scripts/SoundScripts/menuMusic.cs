using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuMusic : MonoBehaviour {

	public static menuMusic musicMenu = null;  

	// Use this for initialization
	void Start () {
		if (musicMenu == null) {
			//if not, set instance to this
			musicMenu = this;
			//If instance already exists and it's not this:
		} else if (musicMenu != this) {
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    
		}
		if (GameObject.Find ("gameMusic")) {
			Destroy (GameObject.Find ("gameMusic"));
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
