using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Köysi : MonoBehaviour {

	float A;
	public float g;
	public float l;
	public float KoydenJaykkyys;
	float Aika = 0f;

	void Awake (){
		A = Mathf.Sin (Mathf.Deg2Rad * transform.eulerAngles.z);
	}

	void FixedUpdate () {
		Aika += Time.deltaTime;
		transform.rotation = Quaternion.Euler (0, 0, A * Mathf.Cos(Mathf.Pow(g / l, 0.5f) * Aika) * Mathf.Rad2Deg);
		if (A > 0f) {
			A -= KoydenJaykkyys * Time.deltaTime;
		} 
		else {
			A = 0;
		}
	}
}