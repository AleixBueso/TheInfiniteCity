using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPress : MonoBehaviour {

    [SerializeField]
    public bool switchOn = false;

    public GameObject redLightOn;
    public GameObject redLightTerminal;
    public GameObject screen;

    private void Awake()
    {
        redLightOn.SetActive(false);
        redLightTerminal.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!switchOn)
        {
            GetComponent<Animation>().Play("OnOff Switch Anim");
            GetComponent<AudioSource>().Play();
            switchOn = true;
            redLightOn.SetActive(true);
            redLightTerminal.SetActive(true);
            screen.SetActive(true);
        }

        else
        {
            GetComponent<Animation>().Play("OffOn Switch Animation");
            GetComponent<AudioSource>().Play();
            switchOn = false;
            redLightOn.SetActive(false);
            redLightTerminal.SetActive(false);
            screen.SetActive(false);
        }
    }
}
