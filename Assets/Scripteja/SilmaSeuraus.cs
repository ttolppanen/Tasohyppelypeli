using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SilmaSeuraus : MonoBehaviour {

	GameObject Ukko;
	public float Sade = 1f;
	Vector3 ValiVektori;
	float Kulma;
	float EtaisuusUkkoon;


	void Start () {
		Ukko = GameObject.FindGameObjectWithTag ("Pelaaja");
	}

	void FixedUpdate () {
		ValiVektori = Ukko.transform.position - transform.position;
		Kulma = Mathf.Atan2 (ValiVektori.y, ValiVektori.x);
		EtaisuusUkkoon = Mathf.Pow ((Mathf.Pow((ValiVektori.x), 2f) + Mathf.Pow((ValiVektori.y), 2f)), 0.5f);
		transform.position = transform.parent.position +  new Vector3 ((EtaisuusUkkoon / 8) * Sade * Mathf.Cos(Kulma), (EtaisuusUkkoon / 8) * Sade * Mathf.Sin(Kulma));
	}
}
