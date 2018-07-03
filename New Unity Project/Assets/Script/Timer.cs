using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

	float _tempsRestant = 300f; // EN SECONDE

	[SerializeField]
	Text _afficheTemps;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		_tempsRestant -= Time.deltaTime;

		float minRestant = Mathf.Floor(_tempsRestant/60);
		float secRestant = Mathf.Floor(_tempsRestant % 60);
	
		_afficheTemps.text = minRestant.ToString() +" : " + secRestant.ToString();

		if(_tempsRestant==0f){
			Debug.Log("Game Over");
		}
	}
}
