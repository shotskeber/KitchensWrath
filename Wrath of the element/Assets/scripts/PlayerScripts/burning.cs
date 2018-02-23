using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class burning : MonoBehaviour {

	public bool active = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (active) {
			if (gameObject.GetComponent<moveplayer> () != null) {
				gameObject.GetComponent<moveplayer> ().enabled = false;
			} else if (gameObject.GetComponent<moveplayer2> () != null) {
				gameObject.GetComponent<moveplayer2> ().enabled = false;
			} else if (gameObject.GetComponent<moveplayer3> () != null) {
				gameObject.GetComponent<moveplayer3> ().enabled = false;
			} else if (gameObject.GetComponent<moveplayer4> () != null) {
				gameObject.GetComponent<moveplayer4> ().enabled = false;
			}
		}
	}
}
