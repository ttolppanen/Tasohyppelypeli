using UnityEngine;
using System.Collections;

public class KavelyAani : MonoBehaviour {

	public AudioClip[] Aani;
	void KavelyAaniClippi () {
		GetComponent<AudioSource>().clip = Aani[0];
		GetComponent<AudioSource>().Play();
		}
}
