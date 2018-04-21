using UnityEngine;
using System.Collections;

public class PelaajanSeuraus : MonoBehaviour {
	
	public GameObject Pelaaja;
	public Vector3 KameranSiirto;

	void LateUpdate () {
		transform.position = new Vector3(Pelaaja.transform.position.x, 0, 0) + KameranSiirto;
	}
}