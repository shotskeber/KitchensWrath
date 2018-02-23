using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltPlayer : MonoBehaviour
{
    //variables
    public GameObject gameManager;
	public GameObject gameState;
    public GameObject salty;
    public GameObject prefabsalty;
	public gameManager gm;

    private Transform Saltytransform;

    public bool HoldSalt = false;

	void Start ()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
		gameState = GameObject.FindGameObjectWithTag ("gameState");
		gm = gameManager.GetComponent<gameManager> ();
    }

	void Update ()
    {

		if (HoldSalt) {
			GameObject.Find ("saltPrefab").gameObject.transform.position = gameObject.transform.position + new Vector3(0f, 3f, 0f);
		}
		if (gameState.GetComponent<gameState> ().wonLevel == false) {
			if (HoldSalt == true) {
				if (gameObject.GetComponent<moveplayer> () != null) {
					if (gm.p1Points < gm.pointsToWin - 1) {
						gm.p1Points += 1 * Time.deltaTime;
					}
				} else if (gameObject.GetComponent<moveplayer2> () != null) {
					if (gm.p2Points < gm.pointsToWin - 1) {
						gm.p2Points += 1 * Time.deltaTime;
					}
				} else if (gameObject.GetComponent<moveplayer3> () != null) {
					if (gm.p3Points < gm.pointsToWin - 1) {
						gm.p3Points += 1 * Time.deltaTime;
					}
				} else if (gameObject.GetComponent<moveplayer4> () != null) {
					if (gm.p4Points < gm.pointsToWin - 1) {
						gm.p4Points += 1 * Time.deltaTime;
					}
				}
			}
		}
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Salt"))
        {
            Destroy (coll.gameObject);
            HoldSalt = true;
        }
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("element"))
        {
			if (HoldSalt == true) {
				Instantiate (prefabsalty, new Vector3 (1f, 7.5f, 0f), Quaternion.identity);
				HoldSalt = false;
			}
        }
            if (coll.gameObject.CompareTag("pieges"))
        {
            if (HoldSalt == true)
            {
                Instantiate(prefabsalty, new Vector3(1f, 7.5f, 0f), Quaternion.identity);
                HoldSalt = false;
            }
        }
    }
}
