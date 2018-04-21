using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiikkuvaMaaPalikka : MonoBehaviour {

	Vector3 Alkupiste;
	public float XNopeus = 1f;
	public float YNopeus = 0f;
	public float Leveys = 3f;
	public float Korkeus = 0f;
	public float XVaihe = 0f;
	public float YVaihe = 0f;
	public float SirkkeliaVarten = 0;
	float XSuunta = 1f;
	float YSuunta = 1f;

	void Start () {
		Alkupiste = transform.position;
		transform.position += new Vector3 (XVaihe, YVaihe, 0);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.x > Alkupiste.x + Leveys && XSuunta == 1f) {
			XSuunta = -1f;
		}
		if (transform.position.x < Alkupiste.x && XSuunta == -1f) {
			XSuunta = 1f;
		}
		if (transform.position.y > Alkupiste.y + Korkeus && YSuunta == 1f) {
			YSuunta = -1f;
		}
		if (transform.position.y < Alkupiste.y && YSuunta == -1f) {
			YSuunta = 1f;
		}
		transform.position += new Vector3 (XNopeus * Time.deltaTime * XSuunta, YNopeus * Time.deltaTime * YSuunta, 0);
		Vector2 PaallaTarkistus1 = new Vector2(transform.position.x - 0.5f, transform.position.y + 0.5f - SirkkeliaVarten);
		Vector2 PaallaTarkistus2 = new Vector2(transform.position.x + 0.5f, transform.position.y + 0.53f - SirkkeliaVarten);
		Collider2D PaallaOlevaJuttu = Physics2D.OverlapArea(PaallaTarkistus1, PaallaTarkistus2, LayerMask.GetMask("Pelaaja"));
		if (PaallaOlevaJuttu != null && PaallaOlevaJuttu.tag == "Pelaaja"){
			PaallaOlevaJuttu.transform.position += new Vector3 (XNopeus * Time.deltaTime * XSuunta, YNopeus * Time.deltaTime * YSuunta, 0);	
		}
	}
}