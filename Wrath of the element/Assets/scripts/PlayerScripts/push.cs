using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class push : MonoBehaviour {
	// Update is called once per frame
	public bool isPushed = false;
	public float pushForce = 0f;
	public float timerPush = 0f;
	public float charDir = 1f;
	public GameObject mychar;

	void Start(){
		mychar = gameObject;
	}

	void Update () {
		Rigidbody2D rb = GetComponent<Rigidbody2D>();
		if (isPushed) {
			if (timerPush < 0.30) {
				disable ();
				rb.velocity = new Vector2 ((pushForce*1.25f)*charDir, 10f);
				timerPush += Time.deltaTime;
			} else {
				enable ();
				isPushed = false;
				timerPush = 0f;
				rb.velocity = new Vector2 (20f*charDir, 0f);
			}
		}
	}

	public void pushChar(float direction, float force){
		isPushed = true;
		pushForce = force;
		charDir = direction;
	}
	void disable(){
		if (mychar.GetComponent<moveplayer> () != null) {
			mychar.GetComponent<moveplayer> ().enabled = false;
		}else if (mychar.GetComponent<moveplayer2> () != null) {
			mychar.GetComponent<moveplayer2> ().enabled = false;
		}else if (mychar.GetComponent<moveplayer3> () != null) {
			mychar.GetComponent<moveplayer3> ().enabled = false;
		}else if (mychar.GetComponent<moveplayer4> () != null) {
			mychar.GetComponent<moveplayer4> ().enabled = false;
		}
	}
	void enable(){
		if (mychar.GetComponent<moveplayer> () != null) {
			mychar.GetComponent<moveplayer> ().enabled = true;
		}else if (mychar.GetComponent<moveplayer2> () != null) {
			mychar.GetComponent<moveplayer2> ().enabled = true;
		}else if (mychar.GetComponent<moveplayer3> () != null) {
			mychar.GetComponent<moveplayer3> ().enabled = true;
		}else if (mychar.GetComponent<moveplayer4> () != null) {
			mychar.GetComponent<moveplayer4> ().enabled = true;
		}
	}
}
