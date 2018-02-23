using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fxSounds : MonoBehaviour {

	public AudioClip[] fxClips;
	private GameObject instance;

	void Update()
	{
		instance = GameObject.Find ("soundManager");
	}

	public void alarmStart(){
		instance.GetComponent<soundManager> ().runSound (fxClips [0]);
	}
	public void meatFall(){
		instance.GetComponent<soundManager> ().runSound (fxClips [1]);
	}
	public void meatHit(){
		instance.GetComponent<soundManager> ().runSound (fxClips [2]);
	}
	public void windStart(){
		instance.GetComponent<soundManager> ().runSound (fxClips [3]);
	}
}
