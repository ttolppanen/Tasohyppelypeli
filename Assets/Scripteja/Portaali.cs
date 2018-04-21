using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portaali : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D Ukko){
		if (Ukko.tag == "Pelaaja" && Ukko != null){
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		}
	}
}
