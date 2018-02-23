using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewOilScript : MonoBehaviour
{
    public PhysicsMaterial2D Slippery;
    public GameObject Prefaboil;
	public GameObject clone;

    private GameObject[] players;
	private ParticleSystem runFX;

	void Start ()
    {
        
    }
	
    void OnTriggerEnter2D(Collider2D coll)
    {

        //players = coll.gameObject.FindGameObjectsWithTag ("Player");
        if (coll.tag == "Player")
        {
            coll.gameObject.GetComponent<Rigidbody2D>().sharedMaterial = Slippery;
            //+ new Vector3(0f,1.8f,0)
            bool spawned = false;
            foreach (Transform t in coll.transform)
            {
                if (t.CompareTag("oilDrop"))
                {
                    spawned = true;
                }
                if (t.name == "runchar1")
                {
                    runFX = t.GetComponent<ParticleSystem>();
                    t.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
                }
                if (t.name == "runchar2")
                {
                    runFX = t.GetComponent<ParticleSystem>();
                    t.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
                }
                if (t.name == "runchar3")
                {
                    runFX = t.GetComponent<ParticleSystem>();
                    t.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
                }
                if (t.name == "runchar14")
                {
                    runFX = t.GetComponent<ParticleSystem>();
                    t.GetComponent<ParticleSystem>().Stop(true, ParticleSystemStopBehavior.StopEmitting);
                }
            }
            if (!spawned)
            {
                clone = Instantiate(Prefaboil, coll.transform.position - new Vector3(0f, 1f, 0), Quaternion.identity);
                clone.transform.parent = coll.transform;
                StartCoroutine(delete(coll.gameObject, clone.gameObject));
            }
        }

    }
    void Update()
    {
        
    }
    
	IEnumerator delete(GameObject player, GameObject drop)
    {
        yield return new WaitForSeconds(7);
        if (player.gameObject != null) {
			player.gameObject.GetComponent<Rigidbody2D> ().sharedMaterial = null;
        }
    }
}
