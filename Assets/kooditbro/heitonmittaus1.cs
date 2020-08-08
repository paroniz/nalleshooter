using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heitonmittaus1 : MonoBehaviour {
    
    private float rinkiZ = 0f;
    private float rinkiX = 0f;
    public bool mitattu = false;

    private GameObject teksti = null;
    private float paras_tulos = 0f;

    private GameObject ohjeteksti = null;

    void Start() {
        this.rinkiZ = GameObject.Find("heittorinki").GetComponent<Transform>().position.z;
        this.rinkiX = GameObject.Find("heittorinki").GetComponent<Transform>().position.x;
        this.teksti = GameObject.Find("tauluteksti2");
        this.ohjeteksti = GameObject.Find("ohjeteksti1");
    }

    void Update() {}

    void OnCollisionEnter(Collision tiedot) {
        if ((tiedot.gameObject.name.Equals("NalleX")) && (!this.mitattu)){
            ContactPoint eka_osuma = tiedot.contacts[0];
            this.mitattu = true;
            float nalleZ = eka_osuma.point.z;
            float nalleX = eka_osuma.point.x;
            float deltaZ = Mathf.Abs(nalleZ-this.rinkiZ);
            float deltaX = Mathf.Abs(nalleX-this.rinkiX);
            float heitonpituus = Mathf.Sqrt((deltaZ*deltaZ)+(deltaX*deltaX));
            if (heitonpituus > this.paras_tulos){
                this.paras_tulos = heitonpituus;
            }
                this.teksti.GetComponent<TextMesh>().text =
                    "Paras tulos: " + this.paras_tulos.ToString("0.00") + " m\n" +
                    "Heiton pituus: " + heitonpituus.ToString("0.00") + " m";  
                this.ohjeteksti.GetComponent<TextMesh>().color = Color.red;
                this.ohjeteksti.GetComponent<TextMesh>().text = "Käy ringin ulkopuolella";
        }
    }
}
