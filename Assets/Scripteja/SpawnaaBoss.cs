using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnaaBoss : MonoBehaviour {

	public GameObject Boss;
	public GameObject Pylvas;

	void OnTriggerEnter2D(Collider2D Ukko){
		Instantiate (Boss, new Vector3(40f, 0.9f, 0), Quaternion.identity);
		Instantiate (Pylvas, new Vector3(27.5f, 7f, 0), Quaternion.identity);
		gameObject.SetActive (false);
	}
}