using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heittokoodi1 : MonoBehaviour {
    
    public Rigidbody nalleammus1 = null;
    private float voima = 0f;
    private float kiertovoima =1000f;
    private Vector3 kiertokertoimet = new Vector3(0.2f,0.4f,0.8f);
    private GameObject rinki = null;
    private GameObject alusta = null;
    
    void Start() {
        this.rinki = GameObject.Find("heittorinki");
        this.alusta = GameObject.Find("alusta");
    }

    void Update() {
        if (Input.GetButtonUp("Fire1"))
        {
            if((this.rinki.GetComponent<asturinkiin1>().voiheittaa) && (!this.rinki.GetComponent<asturinkiin1>().heitetty)){
                this.alusta.GetComponent<heitonmittaus1>().mitattu = false;
                Quaternion asento = new Quaternion(0f, 90f, 90f, 0f);
                Rigidbody nallekuula = (Rigidbody)Instantiate(this.nalleammus1, this.transform.position, asento);
                nallekuula.name = "NalleX";
                voima = this.rinki.GetComponent<asturinkiin1>().voimalaskuri;
                nallekuula.AddForce(this.transform.forward * voima);
                nallekuula.AddTorque(this.kiertokertoimet * this. kiertovoima);
                Destroy(nallekuula.gameObject, 10f);

                this.rinki.GetComponent<asturinkiin1>().heitetty = true;
            }
        }
    }
}
