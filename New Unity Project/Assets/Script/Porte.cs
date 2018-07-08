using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porte : Interactable {

	override protected void Action(){
		Parler.Parleureur.Parle(PersoManager.Char.Me,"They locked me in, I can't leave");
	}
}