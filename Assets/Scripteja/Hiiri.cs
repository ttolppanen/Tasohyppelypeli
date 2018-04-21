using UnityEngine;
using System.Collections;

public class Hiiri : MonoBehaviour {

	void Awake(){
		Cursor.visible = false;
	}

	void FixedUpdate () {
		transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		transform.position += new Vector3(0, 0, 3);
	}
}
