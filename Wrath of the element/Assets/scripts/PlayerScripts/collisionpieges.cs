using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionpieges : MonoBehaviour
{
	public Camera mainCamera;

	void Start(){
		mainCamera = Camera.main;
	}
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.CompareTag ("element")) {
			Destroy (gameObject);
			mainCamera.GetComponent<camShake> ().shakeDuration = 0.45f;
		}
		if (other.gameObject.CompareTag ("pieges")) {
			Destroy (gameObject);
			mainCamera.GetComponent<camShake> ().shakeDuration = 0.45f;
		}
		if (other.gameObject.CompareTag ("fire")) {
			if (gameObject.GetComponent<moveplayer> () != null) {
				gameObject.GetComponent<moveplayer> ().burning = true;
			} else if (gameObject.GetComponent<moveplayer2> () != null) {
				gameObject.GetComponent<moveplayer2> ().burning = true;
			} else if (gameObject.GetComponent<moveplayer3> () != null) {
				gameObject.GetComponent<moveplayer3> ().burning = true;
			} else if (gameObject.GetComponent<moveplayer4> () != null) {
				gameObject.GetComponent<moveplayer4> ().burning = true;
			}
		}
    }
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("fire")) {
			if (gameObject.GetComponent<moveplayer> () != null) {
				gameObject.GetComponent<moveplayer> ().burning = true;
			} else if (gameObject.GetComponent<moveplayer2> () != null) {
				gameObject.GetComponent<moveplayer2> ().burning = true;
			} else if (gameObject.GetComponent<moveplayer3> () != null) {
				gameObject.GetComponent<moveplayer3> ().burning = true;
			} else if (gameObject.GetComponent<moveplayer4> () != null) {
				gameObject.GetComponent<moveplayer4> ().burning = true;
			}
		}
		if (other.gameObject.CompareTag ("pieges")) {
			Destroy (gameObject);
			mainCamera.GetComponent<camShake> ().shakeDuration = 0.45f;
        }
		if (other.gameObject.CompareTag ("element")) {
			Destroy (gameObject);
			mainCamera.GetComponent<camShake> ().shakeDuration = 0.45f;
		}
	}
	void OnCollisionStay2D(Collision2D coll) {
		if (coll.gameObject.tag == "element") {
			Destroy (gameObject);
			mainCamera.GetComponent<camShake> ().shakeDuration = 0.45f;
		}
	}
}
