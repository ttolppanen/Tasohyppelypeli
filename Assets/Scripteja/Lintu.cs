using UnityEngine;
using System.Collections;

public class Lintu : MonoBehaviour {

	GameObject Ukko;
	public GameObject LihaSpawneri;
	public float Nopeus = 10f;

	void Awake(){
		Ukko = GameObject.FindWithTag ("Pelaaja");
	}

	void FixedUpdate(){
		Vector3 Suunta = Vector3.Normalize(transform.position - Ukko.transform.position);
		transform.position -= Suunta * Time.deltaTime * Nopeus;
		if (Suunta.x > 0) {
			transform.localScale = new Vector3 (1, 1, 1);
		} 
		else {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
	}

	void OnTriggerEnter2D(Collider2D MihinTormataan){
		if (MihinTormataan != null && MihinTormataan.tag == "Pelaaja"){
			Ukko.gameObject.GetComponent<Liikkuminen> ().Kuollut = true;
			Instantiate (LihaSpawneri, Ukko.transform.position, Quaternion.identity);
		}
	}
}