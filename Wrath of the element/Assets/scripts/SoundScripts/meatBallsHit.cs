using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatBallsHit : MonoBehaviour {

	public GameObject fxSounds;
	public bool played = false;
	// Use this for initialization
	void Start () {
		fxSounds = GameObject.FindGameObjectWithTag ("soundFx");
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D(Collision2D coll) {
			if (played == false) {
				played = true;
				fxSounds.GetComponent<fxSounds> ().meatHit ();
			}
	}
}
