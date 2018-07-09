using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinker : MonoBehaviour {

	private SpriteRenderer _monAffichage;

	[SerializeField]
	private Sprite _cursorQuest0;
	[SerializeField]
	private Sprite _cursorQuest1;
	// Use this for initialization
	void Start () {
		_monAffichage=GetComponent<SpriteRenderer>();
		StartCoroutine(Blink());
	}
	IEnumerator Blink(){
		int compteur=1;
		while(true){
			yield return new WaitForSeconds(1);
			if(compteur==1){
				_monAffichage.sprite=_cursorQuest1;
				compteur-=1;
			}else{
				_monAffichage.sprite=_cursorQuest0;
				compteur+=1;
			}
			
		}
	}
}
