using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateButtonPress : MonoBehaviour {

    public GameObject screenImage;

    private void Awake()
    {
        GetComponent<Animator>().enabled = false;
        screenImage.GetComponent<Animation>().Play("Logo");
    }

    private void OnMouseDown()
    {
            GetComponent<Animator>().enabled = true;
            GetComponent<Animator>().Play(0);
            GetComponent<AudioSource>().Play();
            screenImage.GetComponent<Animation>().Play("Generating");
            StartCoroutine(ScreenDelay());

    }

    IEnumerator ScreenDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().enabled = true;
        screenImage.GetComponent<Animation>().Play("Done!");
    }
}
