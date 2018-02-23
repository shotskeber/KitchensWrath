using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MeatBalls : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawn;
    public GameObject gameStateObj;
    public float eventDuration = 10f;
    public GameObject[] meatballs;
	public GameObject meatAlert;
	public List<GameObject> tempAlerts = new List<GameObject>();
	public GameObject fxSounds;
	public int soundQty = 0;
	public GameObject gameManager;
    public GameObject alertPrefab;

    private float timerReal = 0f;

    public GameObject tempAlert;

    void Start()
    {
		gameManager = GameObject.FindGameObjectWithTag("GameManager");
		fxSounds = GameObject.FindGameObjectWithTag ("soundFx");
        gameStateObj = GameObject.FindGameObjectWithTag("gameState");
        spawn = gameObject.transform;
		fxSounds.GetComponent<fxSounds> ().alarmStart ();
		InvokeRepeating ("meatsound", 0.5f, 0.75f);

        tempAlert = Instantiate(alertPrefab, new Vector3(0, 2.5f, 0), Quaternion.identity);

        float[] positions = new float[] {-27.5f, -19.9f,-10f,-5f, -3.7f,5f, 9.3f,10f, 19.9f, 27.5f };
        for (int i = 0; i < 5; i++)
        {
            float rndX = Random.Range(0, 8);
            int posX = (int)Mathf.Round(rndX);
            if (posX == 8)
            {
                posX = 7;
            }
            float posFin = (float)positions[posX];
			if(posFin != 0) {
				tempAlerts.Add(Instantiate (meatAlert, new Vector3 (posFin, 16.5f, 0), Quaternion.identity));
				StartCoroutine(spawnMeatBalls(posFin, (float)i));
                positions[posX] = 0;
            }else{
                i--;
            }

        }
    }
	void meatsound(){
		if (soundQty < 5) {
			fxSounds.GetComponent<fxSounds> ().meatFall ();
		} else {
			CancelInvoke ();
		}
		soundQty++;
	}
	IEnumerator spawnMeatBalls(float posFin, float posY){
		yield return new WaitForSeconds (2f);
        Destroy(tempAlert);
		Instantiate(prefab, new Vector3(posFin, spawn.position.y+(20*posY), 0), Quaternion.identity);
	}
    void Update ()
    {
        if (timerReal > eventDuration)
        {
            gameStateObj.GetComponent<elementSpawner>().eventPlaying = false;
            gameStateObj.GetComponent<elementSpawner>().timerDelays = 0f;
            meatballs = GameObject.FindGameObjectsWithTag("element");
            Destroy(gameObject);
			for (int a = 0; a < tempAlerts.Count; a++) {
				Destroy (tempAlerts [a]);
			}
            for(int i=0; i<meatballs.Length; i++)
            {
                Destroy(meatballs[i]);
            }
        }

        if (timerReal < eventDuration)
        {
            timerReal += Time.deltaTime;
    }
}
}
