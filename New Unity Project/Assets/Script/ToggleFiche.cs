using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFiche : MonoBehaviour {

	[SerializeField]
	private PersoManager.Char _maCible;
	private AudioSource _monSonFiche;
	void Start()
	{
		_monSonFiche=GetComponent<AudioSource>();
	}

	void OnMouseUp()
	{
		_monSonFiche.Play();
		if(_maCible == PersoManager.Char.None){
			transform.parent.parent.Find("Computer").gameObject.SetActive(true);
		}else{
			transform.parent.parent.Find(_maCible.ToString()).gameObject.SetActive(true);
		}
			transform.parent.gameObject.SetActive(false);
			CursorManager.instance.ToggleCursor();
	}

	void OnMouseEnter()
	{
		CursorManager.instance.ToggleCursor();
	}
	void OnMouseExit()
	{
		CursorManager.instance.ToggleCursor();
	}
}
