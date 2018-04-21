using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeliMestari : MonoBehaviour {

	public GameObject Pelaaja;
	public GameObject CheckPointTarkistaja;
	GameObject[] Linnut;


	void Update () {
		if (Input.GetKeyDown ("r") && Pelaaja.GetComponent<Liikkuminen>().Kuollut){
			Pelaaja.transform.position = CheckPointTarkistaja.transform.position + new Vector3 (0, 3f, 0);
			Pelaaja.gameObject.GetComponent<Liikkuminen> ().Kuollut = false;
			Linnut = GameObject.FindGameObjectsWithTag ("Vihollinen");
			foreach (GameObject Lintu in Linnut){
				if (Lintu.name.Contains("Lintu")){
					Destroy(Lintu);
				}
			}
		}
	}
}