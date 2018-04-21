using UnityEngine;
using System.Collections;

public class Liha : MonoBehaviour {

	public float TippumisKiihtyvyys = 10f;
	public float NousuNopeus = 10f;
	public float Raja = 10f;
	public float KorkeusRaja = 1f;
	float TippumisNopeus;
	float RandomiLuku;
	float RandomiKorkeus;

	void Start () {
		RandomiLuku = Random.Range (-Raja, Raja);
		RandomiKorkeus = Random.Range (0.5f, KorkeusRaja);
	}
	

	void FixedUpdate () {
		TippumisNopeus += TippumisKiihtyvyys * Time.deltaTime;
		transform.position += new Vector3 (RandomiLuku * Time.deltaTime, RandomiKorkeus * NousuNopeus * Time.deltaTime, 0);
		transform.position -= new Vector3 (0, TippumisNopeus * Time.deltaTime, 0);
		if (transform.position.y < -5f){
			Destroy (this.gameObject);
		}
	}
}
