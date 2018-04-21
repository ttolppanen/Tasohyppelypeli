using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tippuminen : MonoBehaviour {

	float TippumisVakio = 20f;
	float TippumisNopeus = 0f;

	void FixedUpdate () {
		if (transform.position.y > 0.9f) {
			TippumisNopeus += TippumisVakio * Time.deltaTime;
			transform.position -= new Vector3 (0, TippumisNopeus * Time.deltaTime, 0);
		}
		else{
			transform.position = new Vector3 (transform.position.x, 0.9f, 0);
		}
	}
}
