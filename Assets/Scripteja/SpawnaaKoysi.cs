using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnaaKoysi : MonoBehaviour {

	public GameObject Koysi;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("k")){
			Instantiate(Koysi, new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z), Quaternion.Euler(0, 0, 90f));
		}
	}
}
