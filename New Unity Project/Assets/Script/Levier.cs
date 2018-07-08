﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levier : Interactable {

	[SerializeField]
	private PersoManager.Char _monPrisonier;

	[SerializeField]
	private bool _door=false;

	[SerializeField]
	private PrisonManager.Prison _maPrison;
	private bool _isOpen=false;
	private const float DecalageLevier=0.450f;

	Transform imgLevier;

	private PrisonManager _prisonManager;
	override protected void Start(){

		_PersoManager=GameObject.Find("GameManager").GetComponent<PersoManager>();
		_prisonManager=GameObject.Find("GameManager").GetComponent<PrisonManager>();
		imgLevier=transform.Find("AfficheLevier");
		if(_maPrison==PrisonManager.Prison.c0){
			toggleLevier();
		}
	}

	override protected void Action(){
		if(_door){
			if(!_isOpen){
					toggleLevier();
					transform.parent.Find("Levier_"+PrisonManager.getCurrentPrison.ToString()).gameObject.GetComponent<Levier>().toggleLevier();
					_prisonManager.PrisonChange(_maPrison);
			}else{
				Parler.Parle(PersoManager.Char.Me,"There must be at least one of those levers up at all time");
			}
		}else{
			if(!_isOpen){
				if(PersoManager.getCurrentChar!=PersoManager.Char.None){
					Parler.Parle(PersoManager.Char.Me,"I can't get 2 subjects out at the same time...");
				}else{
					toggleLevier();
					_PersoManager.PersoChange(_monPrisonier);
				}
			}else{
				toggleLevier();
				_PersoManager.PersoChange(PersoManager.Char.None);

			}
		}
	}

	//Force le changment d'Etat d'un levier
	private void toggleLevier(){
		if(_isOpen){
			_isOpen=false;
			imgLevier.position=transform.position;
		}else{
			_isOpen=true;
			imgLevier.position=new Vector3(transform.position.x,transform.position.y+DecalageLevier,transform.position.z);
		}

	}
}