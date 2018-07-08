using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parler : MonoBehaviour {
	static public Parler Parleureur;
	private Text _monText;

	private void Start(){
		_monText=transform.Find("Parole").GetComponent<Text>();
		Parleureur=this;
	}
	public void Parle(PersoManager.Char parleur,string ceQuiDit){
		_monText.text=ceQuiDit.ToUpper();
		//ICI ON PLACE LA FACE DU GARS
		transform.position=new Vector3(transform.position.x,80,transform.position.z);
		
		StartCoroutine("Discute");
	}

	IEnumerator Discute(){
	/**	while(true){
			if(Input.GetMouseButtonDown(0)){
				transform.position=new Vector3(transform.position.x,-60,transform.position.z);
				yield return null;
			}
			yield return new WaitForEndOfFrame();
		} **/
		
		//cheker pour attendre un nombre de sec ou click
		yield return new WaitForSeconds(4);
		transform.position=new Vector3(transform.position.x,-60,transform.position.z);
	}

}
