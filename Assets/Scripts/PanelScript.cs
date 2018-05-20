using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelScript : MonoBehaviour {

    public GameObject onSwitch;
    public GameObject generateButton;

	// Use this for initialization
	void Start () {
        onSwitch.GetComponent<Animator>().enabled = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        
    }
}
