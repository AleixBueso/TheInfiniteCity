using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkScript : MonoBehaviour {

    public float minTime = 0;

    private float timer = 0;

	// Update is called once per frame
	void Update () {

        if (timer >= (minTime + Random.Range(10, 30)))
        {
            StartCoroutine(Blink());
            timer = 0;
        }

        timer += Time.deltaTime;
	}

    IEnumerator Blink()
    {
        GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Light>().enabled = false;
        yield return new WaitForSeconds(0.1f);
        GetComponent<Light>().enabled = true;
        yield return new WaitForSeconds(0.1f);
    }
}
