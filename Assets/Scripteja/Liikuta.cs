using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liikuta : MonoBehaviour {
	
	public float XNopeys;
	public float YNopeys;
	float Suunta = 1;
	bool OnOff = false;

	void FixedUpdate () {
		if (OnOff){
			transform.position += new Vector3 (XNopeys * Time.deltaTime * Suunta, YNopeys * Time.deltaTime * Suunta, 0);
		}
	}
	void LiikutaYlos(){
		OnOff = true;
		Suunta = 1;
	}	
	void LiikutaAlas(){
		OnOff = true;
		Suunta = -1;
	}	
	void LiikutaOff(){
		OnOff = false;
	}	
}
