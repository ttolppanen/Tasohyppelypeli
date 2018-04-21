using UnityEngine;
using System.Collections;

public class SirkkeliScripti : MonoBehaviour {
	
	GameObject Ukko;
	public GameObject LihaSpawneri;

	void Awake(){
		Ukko = GameObject.FindGameObjectWithTag ("Pelaaja");
	}

	void OnTriggerEnter2D (Collider2D MihinTormattiin) {
		if (MihinTormattiin.tag != null && MihinTormattiin.tag == "Vihollinen"){
			Destroy(MihinTormattiin.gameObject);
			Instantiate (LihaSpawneri, MihinTormattiin.gameObject.transform.position, Quaternion.identity);
		}
		if (MihinTormattiin.tag != null && MihinTormattiin.tag == "Pelaaja"){
			Ukko.gameObject.GetComponent<Liikkuminen> ().Kuollut = true;
			Instantiate (LihaSpawneri, Ukko.transform.position, Quaternion.identity);
		}
	}
}
