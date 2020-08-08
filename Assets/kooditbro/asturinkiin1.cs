using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class asturinkiin1 : MonoBehaviour {

    public float voimalaskuri = 0f;
    public bool voiheittaa = false;
    public bool heitetty = false;
    private int nappainlaskuri = 0;
    private bool ringissa_ok = false;
    private float aloitusaika = 0f;

    private GameObject ohjeteksti = null;
    
    void Start() {
        this.ohjeteksti = GameObject.Find("ohjeteksti1");
    }

    void Update()
    {
        if ((Input.GetKeyUp(KeyCode.P)) && (this.ringissa_ok) && (!this.heitetty))
        {
            if (this.nappainlaskuri == 0)
            {
                this.aloitusaika = Time.time;
            }
            
            if (this.nappainlaskuri < 20)
            {
                this.nappainlaskuri++;
            }

            if (this.nappainlaskuri == 20)
            {
                this.voiheittaa = true;
                this.ohjeteksti.GetComponent<TextMesh>().text = "VOI HEITTÄÄ!";
                Debug.Log("Voimalaskuri : " + this.voimalaskuri);

                this.voimalaskuri = Time.time - this.aloitusaika;
                this.voimalaskuri = (1 / this.voimalaskuri) * 14000f;
                this.ringissa_ok = false;
            }
        }
    }

    void OnTriggerEnter(Collider tiedot){
        if (tiedot.name.Equals("pelaaja")){
            this.ohjeteksti.GetComponent<TextMesh>().color = Color.green;
            this.ohjeteksti.GetComponent<TextMesh>().text = " VOI HEITTÄÄ!";
           
            this.voimalaskuri = 0f;
            this.nappainlaskuri = 0;
            this.ringissa_ok = true;
        }
    }
    
    void OnTriggerExit(Collider tiedot){
        if (tiedot.name.Equals("pelaaja")){
            this.ohjeteksti.GetComponent<TextMesh>().color = Color.red;
            this.ohjeteksti.GetComponent<TextMesh>().text = " ASTU RINKIIN!";
            this.voiheittaa = false;
            this.heitetty = false;
            this.ringissa_ok  = false;
        }
    }
}
