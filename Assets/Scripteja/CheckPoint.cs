using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public GameObject CheckPointTarkistaja;

	void OnTriggerEnter2D (Collider2D Tormattava){
		if (Tormattava != null && Tormattava.tag == "Pelaaja") {
			CheckPointTarkistaja.transform.position = transform.position;
		}
	}
}
