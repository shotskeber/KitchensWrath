﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundManager : MonoBehaviour{

	public float masterVolume = 1f;
	public static soundManager soundInstance = null;

	void Awake(){
		if (soundInstance == null) {
			//if not, set instance to this
			soundInstance = this;
			//If instance already exists and it's not this:
		} else if (soundInstance != this) {
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);    
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);
	}
	// Update is called once per frame
	void Update () {
		GetComponent<AudioSource> ().volume = masterVolume;
	}

	public void runSound(AudioClip clip){
		GetComponent<AudioSource> ().volume = masterVolume;
		GetComponent<AudioSource> ().PlayOneShot (clip);
	}
}