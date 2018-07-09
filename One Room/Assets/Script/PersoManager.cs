using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoManager : MonoBehaviour {

	public enum Char {Bonnie,Amelia,Bernard,Chips,None,Me};

	static private Char CurrentChar;

	private GameObject _monAffichage;

	private SpriteRenderer _laPorte;
	// Use this for initialization
	void Start () {
		CurrentChar=Char.None;
		_monAffichage=GameObject.Find("PersoAffiche");
		_laPorte=GameObject.Find("Fond").GetComponent<SpriteRenderer>();
		PersoChange(Char.None);
		
	}
	public void PersoChange(Char newPerso){
		if(newPerso==Char.None){
			_monAffichage.GetComponent<SpriteRenderer>().sprite=null;
			_laPorte.sprite=Resources.Load<Sprite>("Door/"+Char.Bonnie.ToString());
			switch(CurrentChar){
				case Char.Amelia:Parler.Parleureur.Parle(CurrentChar,"O-Oh, if that’s what you want…");break;
				case Char.Bonnie:Parler.Parleureur.Parle(CurrentChar,"Tsk, I don’t like being in there. Don’t keep me waiting ");break;
				case Char.Bernard:Parler.Parleureur.Parle(CurrentChar,"Understood. Call me back if you need me.");break;
				case Char.Chips:Parler.Parleureur.Parle(CurrentChar,"Ah men there’s nothing cool to do in there!");break;
			}
		}else{
			_monAffichage.GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("Perso/"+newPerso.ToString());
			_laPorte.sprite=Resources.Load<Sprite>("Door/"+newPerso.ToString());
			switch(newPerso){
				case Char.Bonnie:Parler.Parleureur.Parle(newPerso,"Need me? I’m all yours, darling.");break;
				case Char.Amelia:Parler.Parleureur.Parle(newPerso,"I’m out… what do you need me to do?");break;
				case Char.Bernard:Parler.Parleureur.Parle(newPerso,"Alright. Just warn me before spinning that crazy room, speaker boy.");break;
				case Char.Chips:Parler.Parleureur.Parle(newPerso,"You called me? Found explosives? Lizardfolks? Oh, both?!");break;
			}
			
		}
		CurrentChar=newPerso;
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