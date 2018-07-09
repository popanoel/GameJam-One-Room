using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
	protected PersoManager _PersoManager;
	protected bool _isOvered=false;
	protected AudioSource _monSon;
	virtual protected void Start()
	{
		_PersoManager=GameObject.Find("GameManager").gameObject.GetComponent<PersoManager>();
		_monSon=GetComponent<AudioSource>();
	}

	protected virtual void OnMouseUp()
	{
		Action();
	}

	protected virtual void OnMouseEnter()
	{
		_isOvered=true;
		CursorManager.instance.ToggleCursor();
	}
	protected virtual void OnMouseExit()
	{	
		_isOvered=false;
		CursorManager.instance.ToggleCursor();
	}




	protected virtual void Action(){

	}
	
}
