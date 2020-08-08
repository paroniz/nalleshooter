using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kameraohjaus1 : MonoBehaviour {
    
    private GameObject pelaajan_kamera = null;
    
    void Start() {
        this.pelaajan_kamera = GameObject.Find("MainCamera");
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.K)){
            this.pelaajan_kamera.GetComponent<Camera>().enabled = false;
            this.GetComponent<Camera>().enabled = true;
        }
        
        if (Input.GetKeyUp(KeyCode.K)) {
            this.GetComponent<Camera>().enabled = false;
            this.pelaajan_kamera.GetComponent<Camera>().enabled = true;
        }
    }
}
