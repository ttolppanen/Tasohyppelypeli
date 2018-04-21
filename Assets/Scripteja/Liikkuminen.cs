using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Liikkuminen : MonoBehaviour {

	public float VakioMaxNopeus = 10f;
	public float PutoamisKiihtyvyys = 10f;
	public float NopeusLisaus = 1f;
	public float HyppyVakio = 10f;
	public float JuoksuNopeus = 15;
	public AudioClip[] Aanet;
	public GameObject Nyrkki;
	float Nopeus = 0f;
	float PutoamisNopeus = 0f;
	float MaxNopeus;
	float Hyppy = 0f;
	float Kulma;
	bool hypyssa = false;
	bool Lyonnissa = false;
	public bool KatsomisSuunta = true;
	bool SaakoLiikkuaOikealla = true;
	bool SaakoLiikkuaVasemmalle = true;
	public bool Kuollut;
	AudioSource Aanilahde;
	Animator Animaatio;

	void Awake(){
		Aanilahde = GetComponent<AudioSource>();
		Animaatio = GetComponent<Animator>();
		MaxNopeus = VakioMaxNopeus;
		Kuollut = false;
	}

	void FixedUpdate () {
		if (!Kuollut){
			if (Input.GetMouseButton (0) && !Lyonnissa) {
				Animaatio.SetBool ("Lyönti", true);
				Lyonnissa = true;
				Aanilahde.clip = Aanet [1];
				Aanilahde.Play ();
				Vector3 ValiVektori;
				if (Camera.main.ScreenToWorldPoint (Input.mousePosition).x - transform.position.x > 0) {
					ValiVektori = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position +  new Vector3(-0.1f, 0.24f, 0);
					Kaanna ("oikea");
					Kulma = Mathf.Atan2 (ValiVektori.y, ValiVektori.x);
					Instantiate (Nyrkki, transform.position +  new Vector3(-0.1f, 0.24f, 0), Quaternion.Euler (0, 0, Kulma * Mathf.Rad2Deg), transform);
				} else {
					ValiVektori = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position + new Vector3(0.1f, 0.24f, 0);
					Kaanna ("vasen");
					Kulma = Mathf.Atan2 (-ValiVektori.y, -ValiVektori.x);
					Instantiate (Nyrkki, transform.position + new Vector3(0.1f, 0.24f, 0), Quaternion.Euler (0, 0, Kulma * Mathf.Rad2Deg), transform);
				}
			}
			Tormaus();
			if (Input.GetKey(KeyCode.LeftShift)) {
				MaxNopeus = JuoksuNopeus;
			}
			else{
				MaxNopeus = VakioMaxNopeus;
			}
			if (Input.GetKeyDown ("d") || Input.GetKeyDown ("a") || !Input.GetKey ("d") && !Input.GetKey ("a")) {
				Nopeus = 0;
				Animaatio.SetBool("Juoksu", false);
			}
			if (Input.GetKey("d") && SaakoLiikkuaOikealla){
				TarkistaNopeus ();
				transform.position += new Vector3 (Nopeus * Time.deltaTime, 0, 0);
				if (!Lyonnissa) {
					Kaanna ("oikea");
				}
				Animaatio.SetBool("Juoksu", true);
			}
			if (Input.GetKey ("a") && SaakoLiikkuaVasemmalle){
				TarkistaNopeus();
				transform.position -= new Vector3 (Nopeus * Time.deltaTime, 0, 0);
				if (!Lyonnissa) {
					Kaanna ("vasen");
				}
				Animaatio.SetBool("Juoksu", true);
			}
			if (Input.GetKey ("w") && Ilmassa() < 0.1f) {
				hypyssa = true;
				Hyppy = HyppyVakio;
				transform.position += new Vector3 (0, Hyppy * Time.deltaTime, 0);
				PutoamisNopeus = 0;

			}
			if (hypyssa) {
				transform.position += new Vector3 (0, Hyppy * Time.deltaTime, 0);
			}
			float EtaisuusMaahan = Ilmassa ();
			if (Ilmassa() > 0.1f) {
				PutoamisNopeus += PutoamisKiihtyvyys * Time.deltaTime;
				float OletettuMatka = -(Hyppy - PutoamisNopeus) * Time.deltaTime;
				if (PutoamisNopeus * Time.deltaTime > Hyppy * Time.deltaTime && OletettuMatka > EtaisuusMaahan) {
					transform.position -= new Vector3 (0, EtaisuusMaahan, 0);
					Hyppy = 0;
					hypyssa = false;
					PutoamisNopeus = 0;
				} 
				else {
					transform.position -= new Vector3 (0, PutoamisNopeus * Time.deltaTime, 0);
				}
			} 
			else {
				transform.position -= new Vector3 (0, EtaisuusMaahan, 0);
				Hyppy = 0;
				hypyssa = false;
				PutoamisNopeus = 0;
			}
			Animaatio.SetBool("Hyppy", hypyssa);
			}
			if (transform.position.y < -5f) {
				Kuollut = true;
			}
			Animaatio.SetBool ("Kuollut", Kuollut);
		}	
	
	float Ilmassa(){
		float Etaisuus = 10000f;
		for (int i = 0; i <= 2; i++) {
			RaycastHit2D MaaPala = Physics2D.Raycast (new Vector2 (transform.position.x - 0.06f + i * 0.07f, transform.position.y - 0.5f), Vector2.down, Mathf.Infinity, LayerMask.GetMask ("Maa"));
			if (MaaPala.collider != null && MaaPala.distance < Etaisuus) {
				Etaisuus = MaaPala.distance;
			}
		}
		return Etaisuus;
	}
	void Tormaus(){
		Vector2 TormausVektoriVasen1 = new Vector2(transform.position.x - 0.18f, transform.position.y - 0.4f);
		Vector2 TormausVektoriVasen2 = new Vector2(transform.position.x - 0.21f, transform.position.y + 0.5f);
		Vector2 TormausVektoriOikea1 = new Vector2(transform.position.x + 0.18f, transform.position.y - 0.4f);
		Vector2 TormausVektoriOikea2 = new Vector2(transform.position.x + 0.21f, transform.position.y + 0.5f);
		Collider2D MihinTormataanOikea = Physics2D.OverlapArea(TormausVektoriOikea1, TormausVektoriOikea2, LayerMask.GetMask("Maa"));
		Collider2D MihinTormataanVasen = Physics2D.OverlapArea(TormausVektoriVasen1, TormausVektoriVasen2, LayerMask.GetMask("Maa"));
		if (MihinTormataanOikea != null && MihinTormataanOikea.tag == "Maa"){
			SaakoLiikkuaOikealla = false;
		}
		else{
			SaakoLiikkuaOikealla = true;
		}
		if (MihinTormataanVasen != null && MihinTormataanVasen.tag == "Maa"){
			SaakoLiikkuaVasemmalle = false;
		}
		else{
			SaakoLiikkuaVasemmalle = true;
		}
	}
	void TarkistaNopeus(){
		if (Nopeus < MaxNopeus){
			Nopeus += NopeusLisaus;
		}
		if (Nopeus > MaxNopeus){
			Nopeus = VakioMaxNopeus;
		}
		
	}
	bool OnkoNopeutta(){

		if (Nopeus != 0){
			return true;
		}
		else{
			return false;
		}
	}
	void Kaanna(string joo){
		if (joo == "oikea" && !KatsomisSuunta){
			Vector3 Skaala = transform.localScale;
			Skaala.x = Skaala.x * (-1);
			transform.localScale = Skaala;
			KatsomisSuunta = true;
			}
		if (joo == "vasen" && KatsomisSuunta){
			Vector3 Skaala = transform.localScale;
			Skaala.x = Skaala.x * (-1);
			transform.localScale = Skaala;
			KatsomisSuunta = false;
			}
	}

	void SoitaAani(int MikaAani){
		GetComponent<AudioSource>().clip = Aanet[MikaAani];
		GetComponent<AudioSource>().Play();
	}
	void SammutaLyonti (){
		Animaatio.SetBool("Lyönti", false);
		Lyonnissa = false;
	}
}