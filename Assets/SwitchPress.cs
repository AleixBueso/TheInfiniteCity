using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPress : MonoBehaviour {

    private void Awake()
    {
        GetComponent<Animator>().enabled = false;
    }

    private void OnMouseDown()
    {
        GetComponent<Animator>().enabled = true;
        GetComponent<Animator>().Play(0);
        GetComponent<AudioSource>().Play();
    }
}
