using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : Interactable {

	[SerializeField]
	private PersoManager.Char _monPrisonier;
	
	private bool _isOpen=false;
	override protected void AfficheMenu(){
		if(!_isOpen){
			if(PersoManager.getCurrentChar!=PersoManager.Char.None){
				Parler.Parle(PersoManager.Char.Me,"I can't get 2 subjects out at the same time...");
			}else{
				_isOpen=true;
				_PersoManager.PersoChange(_monPrisonier);
			}
		}else{
			_isOpen=false;
			_PersoManager.PersoChange(PersoManager.Char.None);

		}
	}
}
