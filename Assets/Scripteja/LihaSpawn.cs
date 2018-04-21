using UnityEngine;
using System.Collections;

public class LihaSpawn : MonoBehaviour {

	public GameObject Liha;
	public int KuinkaMonta = 10;

	void Start () {
		for (int i = 1; i <= KuinkaMonta; i++) {
			Instantiate (Liha, transform.position, Quaternion.Euler(0f, 0f, 90f));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
