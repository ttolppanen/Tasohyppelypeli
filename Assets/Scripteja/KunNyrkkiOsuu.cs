using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunNyrkkiOsuu : MonoBehaviour {

	GameObject Ukko;
	public bool PitaakoLiikkua = false;
	public bool EiLyontia = true;
	public Vector3 LyontiSuunta;

	void Awake(){
	Ukko = GameObject.FindWithTag ("Pelaaja");
	}

	void FixedUpdate(){
		if (PitaakoLiikkua == true && EiLyontia == true){
			EiLyontia = false;
			GetComponent<AudioSource>().Play();
		}
		if (PitaakoLiikkua == true){
			transform.position += Time.deltaTime * LyontiSuunta;
			if (Mathf.Abs(transform.position.x - Ukko.transform.position.x) > 25){
				Destroy(gameObject);
			}
		}
	}

}