using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPress : MonoBehaviour {

    [SerializeField]
    public bool switchOn = false;

    private GameObject audioManager;

    public GameObject redLightOn;
    public GameObject redLightTerminal;
    public GameObject screen;

    private void Awake()
    {
        redLightOn.SetActive(false);
        redLightTerminal.SetActive(false);
        audioManager = GameObject.FindGameObjectWithTag("AudioManager");
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
            StartCoroutine(TurnOnScreen());
            audioManager.GetComponent<AudioSource>().Play();
        }

        else
        {
            GetComponent<Animation>().Play("OffOn Switch Animation");
            GetComponent<AudioSource>().Play();
            switchOn = false;
            redLightOn.SetActive(false);
            redLightTerminal.SetActive(false);
            screen.SetActive(false);
            audioManager.GetComponent<AudioSource>().Stop();
        }
    }

    IEnumerator TurnOnScreen()
    {
        yield return new WaitForSeconds(1f);
        screen.SetActive(true);
    }
}
