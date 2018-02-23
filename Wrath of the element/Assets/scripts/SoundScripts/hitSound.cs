using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitSound : MonoBehaviour {

	public AudioClip[] hits;
	public int clipIndex;
	private GameObject instance;

	void Update()
	{
		instance = GameObject.Find ("soundManager");
	}

	public void PlaySound()
	{
		clipIndex = Random.Range(0, hits.Length - 1);
		if (instance != null) {
			instance.GetComponent<soundManager> ().runSound (hits [clipIndex]);
		}
	}
}
