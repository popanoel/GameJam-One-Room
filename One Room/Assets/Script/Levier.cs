using System.Collections;
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
		_monSon=GetComponent<AudioSource>();
		imgLevier=transform.Find("AfficheLevier");
		if(_door){
			if(_maPrison==PrisonManager.Prison.c0){
				toggleLevier();
			}
		}
	}

	override protected void Action(){
		_monSon.Play();
		if(_door){
			if(!_isOpen){
					toggleLevier();
					transform.parent.Find("Levier_"+PrisonManager.getCurrentPrison.ToString()).gameObject.GetComponent<Levier>().toggleLevier();
					_prisonManager.PrisonChange(_maPrison);
			}else{
				Parler.Parleureur.Parle(PersoManager.Char.Me,"There must be one of those levers down at all time");
			}
		}else{
			if(!_isOpen){
					toggleLevier();
					if(PersoManager.getCurrentChar!=PersoManager.Char.None){
						transform.parent.Find("Levier_"+PersoManager.getCurrentChar.ToString()).gameObject.GetComponent<Levier>().toggleLevier();
					}
					_PersoManager.PersoChange(_monPrisonier);
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
			imgLevier.position=new Vector3(transform.position.x,transform.position.y+DecalageLevier,transform.position.z);
		}else{
			_isOpen=true;
			imgLevier.position=transform.position;
		}

	}
}
