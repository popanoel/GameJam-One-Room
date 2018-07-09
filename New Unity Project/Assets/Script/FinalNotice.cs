using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalNotice : Interactable {

[SerializeField]
private bool _isBtRouge;
protected override void OnMouseUp()
	{
		if(GameManager.instance._isEnding){
			Action();
		}
	}

	protected override void OnMouseEnter()
	{
		if(GameManager.instance._isEnding){
			_isOvered=true;
			CursorManager.instance.ToggleCursor();
		}
	}
	protected override void OnMouseExit()
	{	
		if(GameManager.instance._isEnding){
			_isOvered=false;
			CursorManager.instance.ToggleCursor();
		}
	}


	protected override void Action(){
		if(_isBtRouge){
			GameManager.instance.Fin();
		}else{
			GameObject.Find("bg").GetComponent<PanelManager>().toggleFinal();
			_isOvered=false;
			CursorManager.instance.ToggleCursor();
		}
	}

}
