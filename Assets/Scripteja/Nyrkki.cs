using UnityEngine;
using System.Collections;

public class Nyrkki : MonoBehaviour {

    public float LyontiVoima = 1f;
    GameObject Ukko;
	float Kulma;
        
	void Awake (){
		Ukko = GameObject.FindWithTag ("Pelaaja");
	}

	void Update (){
		if (Ukko == null) {
			Ukko = GameObject.FindWithTag ("Pelaaja");
		}
	}

    void OnTriggerEnter2D(Collider2D Tormaava){
        if (Tormaava.tag == "Vihollinen"){
			Vector3 ValiVektori = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
			Kulma = Mathf.Atan2 (ValiVektori.y, ValiVektori.x);
			Tormaava.gameObject.GetComponent<KunNyrkkiOsuu>().LyontiSuunta = new Vector3(LyontiVoima * Mathf.Cos(Kulma), LyontiVoima * Mathf.Sin(Kulma) ,0);
            Tormaava.gameObject.GetComponent<KunNyrkkiOsuu>().PitaakoLiikkua = true;
            GetComponent<AudioSource>().Play();
		}
    }
	void LopetaLyonti (){
		Destroy (gameObject);
	}
}