using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinnunSpawneri : MonoBehaviour {

	public float SpawniAika = 10f;
	public GameObject Lintu;
	public float Vali = 10f;
	float Aika = 0f;

	void FixedUpdate () {
		if (Aika > SpawniAika) {
			Vector3 SpawniPaikka = new Vector3 (transform.position.x + Random.Range(-Vali, Vali), transform.position.y, transform.position.z);
			Instantiate (Lintu, SpawniPaikka, Quaternion.identity);
			Aika = 0f;
		} 
		else {
			Aika += Time.deltaTime;
		}
	}
}
