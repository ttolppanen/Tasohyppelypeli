using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlueSpawnaus : MonoBehaviour {

	public GameObject LinnunSpawneri1;
	public GameObject LinnunSpawneri2;
	public GameObject LinnunSpawneri3;

	void OnTriggerEnter2D(Collider2D MihinTormataan){
		if (MihinTormataan != null && MihinTormataan.tag == "Pelaaja") {
			LinnunSpawneri1.SetActive (true);
			LinnunSpawneri2.SetActive (true);
			LinnunSpawneri3.SetActive (true);
		}
	}
	void OnTriggerExit2D(Collider2D MihinTormataan){
		if (MihinTormataan != null && MihinTormataan.tag == "Pelaaja") {
			LinnunSpawneri1.SetActive (false);
			LinnunSpawneri2.SetActive (false);
			LinnunSpawneri3.SetActive (false);
		}
	}
}
