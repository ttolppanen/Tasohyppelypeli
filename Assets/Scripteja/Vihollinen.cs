using UnityEngine;
using System.Collections;

public class Vihollinen : MonoBehaviour {

	public float VihollisenNopeus = 1f;
	public GameObject LihaSpawneri;
	Vector3 UkonPaikka;
	GameObject Ukko;
	float Suunta = 1f;

	// Use this for initialization
	void Awake () {
	Ukko = GameObject.FindWithTag ("Pelaaja");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		RaycastHit2D OnkoAllaTyhjaa = Physics2D.Raycast (new Vector2 (transform.position.x, transform.position.y), Vector2.down, 1f, LayerMask.GetMask ("Maa"));	
		if (OnkoAllaTyhjaa.collider == null) {
			transform.localScale = new Vector3(-1f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
			Suunta *= -1f;
		}
		RaycastHit2D TormataankoOikealle = Physics2D.Raycast (new Vector2 (transform.position.x + 0.1f, transform.position.y), Vector2.right, Mathf.Infinity, LayerMask.GetMask ("Maa"));	
		if (TormataankoOikealle.distance < 0.1f && TormataankoOikealle.distance != 0f){
			transform.localScale = new Vector3(-1f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
			Suunta *= -1f;
		}
		RaycastHit2D TormataankoVasemmalle = Physics2D.Raycast (new Vector2 (transform.position.x - 0.1f, transform.position.y), Vector2.left, Mathf.Infinity, LayerMask.GetMask ("Maa"));	
		if (TormataankoVasemmalle.distance < 0.1f && TormataankoVasemmalle.distance != 0f){
			transform.localScale = new Vector3(-1f * transform.localScale.x, transform.localScale.y, transform.localScale.z);
			Suunta *= -1f;
		}
		transform.position += new Vector3 (-VihollisenNopeus * Suunta * Time.deltaTime, 0, 0);
	}
	void OnTriggerEnter2D(Collider2D MihinTormataan){
		if (MihinTormataan != null && MihinTormataan.tag == "Pelaaja"){
			Ukko.gameObject.GetComponent<Liikkuminen> ().Kuollut = true;
			Instantiate (LihaSpawneri, Ukko.transform.position, Quaternion.identity);
		}
	}
}
