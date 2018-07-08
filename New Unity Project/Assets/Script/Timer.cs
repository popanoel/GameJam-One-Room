using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	float _tempsRestant = 300f; // EN SECONDE
	Text _afficheTemps;


	// Use this for initialization
	void Start () {
		_afficheTemps=GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		_tempsRestant -= Time.deltaTime;

		float minRestant = Mathf.Floor(_tempsRestant/60);
		float secRestant = Mathf.Floor(_tempsRestant % 60);
		string aff_sec = secRestant.ToString();
		string aff_min = minRestant.ToString();
		if(secRestant<=9){aff_sec="0"+aff_sec;}
	
		_afficheTemps.text = aff_min + " : " + aff_sec;

		if(_tempsRestant<=1f){
			GameManager.instance.StartCoroutine("GameO");
		}
	}
}