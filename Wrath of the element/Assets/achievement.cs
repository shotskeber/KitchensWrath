using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class achievement : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(scale(5f, gameObject));
	}

    IEnumerator scale(float finalyscore, GameObject platform)
    {
        Vector3 originalPos = platform.transform.position;
        Vector3 temp = new Vector3(originalPos.x, finalyscore, originalPos.z);
        float currentTime = 0.0f;

        do
        {
            platform.transform.position = Vector3.Lerp(originalPos, temp, currentTime / 1);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= 3);
        yield return new WaitForSeconds(1);
        currentTime = 0.0f;
        do
        {
            platform.transform.position = Vector3.Lerp(temp, originalPos, currentTime / 1);
            currentTime += Time.deltaTime;
            yield return null;
        } while (currentTime <= 3);
        Destroy(gameObject);
        print("done");
    }
}
