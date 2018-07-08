using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoManager : MonoBehaviour {

	public enum Char {Bonnie,Amelia,Bernard,Chips,None,Me};

	static private Char CurrentChar;

	private GameObject _monAffichage;
	// Use this for initialization
	void Start () {
		CurrentChar=Char.None;
		_monAffichage=GameObject.Find("PersoAffiche");
		PersoChange(Char.None);
		
	}
	public void PersoChange(Char newPerso){
		CurrentChar=newPerso;
		if(newPerso==Char.None){
			_monAffichage.GetComponent<SpriteRenderer>().sprite=null;
		}else{
			_monAffichage.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("Perso/"+CurrentChar.ToString());
		}

	}
	static public Char getCurrentChar{
		get{
			return CurrentChar;
		}
		set{
			CurrentChar=value;
		}
	}
}