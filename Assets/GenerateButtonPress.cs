using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GenerateButtonPress : MonoBehaviour {

    public GameObject screenImage;

    private void Awake()
    {

    }

    private void OnMouseDown()
    {
        screenImage.GetComponent<Animator>().SetBool("Menu", true);
        GetComponent<AudioSource>().Play();
        screenImage.GetComponent<Animator>().SetBool("ButtonPressed", true);
        StartCoroutine(ScreenDelay());
    }

    IEnumerator ScreenDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Animator>().enabled = true;

        yield return new WaitForSeconds(2f);
        screenImage.GetComponent<Animator>().SetBool("Generated", true);
        yield return new WaitForSeconds(6f);
        SceneManager.LoadSceneAsync("City");
    }
}
