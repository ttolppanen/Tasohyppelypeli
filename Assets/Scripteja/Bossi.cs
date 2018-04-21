using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bossi : MonoBehaviour {

	public float AloitusHP = 100f;
	public float Nopeus = 5f;
	public float TippumisVakio = 5f;
	public float Hyppy = 10f;
	public float OdotusAika = 2f;
	public float SiirtoAika = 1f;
	public GameObject Lintu;
	public GameObject Saha;
	public Transform OikeaKasi;
	public Transform VasenKasi;
	Vector3 Aloituspiste;
	Animator Animaatio;
	float Tippuminen;
	float Aika = 0f;
	float SiirtoNopeusX;
	float SiirtoNopeusY;
	float HP;
	bool PitaakoOdottaa = false;
	bool Siirretty = false;
	bool SiirtoAloitus = false;

	void Awake (){
		Aloituspiste = transform.position;
		HP = AloitusHP;
		Animaatio = GetComponent<Animator> ();
		Animaatio.SetInteger ("Vaihe", 0);
	}

	void FixedUpdate () {
		if (HP > 0f) {
			if (HP > AloitusHP * 0.75f) {
				EkaVaihe ();
			}
			if (HP < AloitusHP * 0.75f && HP > AloitusHP * 0.5f){
				Siirretaan ();
				if (Siirretty && Animaatio.GetInteger("Vaihe") == 1){
					TokaVaihe ();
				}
			}
		} 
		else {	
			Destroy (gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D MikaOsuu){
		if (MikaOsuu != null && MikaOsuu.tag == "Nyrkki"){
			HP -= 1;
		}
	}
	void EkaVaihe (){
		if (!PitaakoOdottaa) {
			Animaatio.SetBool ("Hypyssa", true);
			Tippuminen += TippumisVakio * Time.deltaTime;
			transform.position += new Vector3 (-Nopeus * Time.deltaTime, (Hyppy - Tippuminen) * Time.deltaTime, 0);
			if (transform.position.y < Aloituspiste.y) {
				Animaatio.SetBool ("Hypyssa", false);
				Tippuminen = 0f;
				transform.position = new Vector3 (transform.position.x, Aloituspiste.y, transform.position.z);
				PitaakoOdottaa = true;
				if (transform.position.x < Aloituspiste.x - 9f) {
					transform.position = new Vector3 (Aloituspiste.x - 10f, transform.position.y, transform.position.z);
					Instantiate (Lintu, new Vector3(transform.position.x - 0.325f, transform.position.y + 1.477f, transform.position.z), Quaternion.identity);
					Instantiate (Lintu, new Vector3(transform.position.x + 0.3f, transform.position.y + 1.477f, transform.position.z), Quaternion.identity);
					Nopeus *= -1;
				} 
				if (transform.position.x > Aloituspiste.x - 1f){
					transform.position = new Vector3 (Aloituspiste.x, transform.position.y, transform.position.z);
					Instantiate (Lintu, new Vector3(transform.position.x - 0.325f, transform.position.y + 1.477f, transform.position.z), Quaternion.identity);
					Instantiate (Lintu, new Vector3(transform.position.x + 0.3f, transform.position.y + 1.477f, transform.position.z), Quaternion.identity);
					Nopeus *= -1;
				}
			}
		} 
		else {
			if (Aika > OdotusAika) {
				PitaakoOdottaa = false;
				Aika = 0;
			} 
			else {
				Aika += Time.deltaTime;
			}
		}
	}
	void TokaVaihe(){
		
	}
	void Siirretaan(){
		if (!SiirtoAloitus) {
			SiirtoNopeusX = (Aloituspiste.x - transform.position.x) / SiirtoAika;
			SiirtoNopeusY = ((Aloituspiste.y - transform.position.y) / SiirtoAika) + (1f/2f * TippumisVakio * SiirtoAika);
			SiirtoAloitus = true;
			Tippuminen = 0f;
		}
		if (!Siirretty){
			Tippuminen += TippumisVakio * Time.deltaTime;
			transform.position += new Vector3 (SiirtoNopeusX * Time.deltaTime, (SiirtoNopeusY - Tippuminen) * Time.deltaTime);
			if (transform.position.y < Aloituspiste.y) {
				Animaatio.SetBool ("AloitusSaha", true);
				Animaatio.SetBool ("Hypyssa", false);
				Tippuminen = 0f;
				transform.position = new Vector3 (Aloituspiste.x, Aloituspiste.y, transform.position.z);
				Siirretty = true;
			}
		}
	}
	void SammutaSahat(){
		Animaatio.SetBool ("AloitusSaha", false);
	}
	void LuoSahat(){
		Instantiate (Saha, OikeaKasi, false);
		Instantiate (Saha, VasenKasi, false);
	}
	void MuutaVaihe(int Vaihe){
		Animaatio.SetInteger ("Vaihe", Vaihe);
	}
}