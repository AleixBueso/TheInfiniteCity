using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateButtonPress : MonoBehaviour {

    private void Awake()
    {
        GetComponent<Animator>().enabled = false;
    }

    private void OnMouseDown()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().Play(0);
        GetComponent<AudioSource>().Play();
        StartCoroutine(ScreenDelay());
    }

    IEnumerator ScreenDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().enabled = true;
    }
}
