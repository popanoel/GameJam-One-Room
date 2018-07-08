using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

	[SerializeField]
	private PersoManager.Char Mychef;

	private GameObject _menu;

	protected PersoManager _PersoManager;
	virtual protected void Start()
	{
		_menu=Resources.Load<GameObject>("Menu");
		_PersoManager=GameObject.Find("GameManager").gameObject.GetComponent<PersoManager>();
	}

	void OnMouseUp()
	{
		Action();
	}
	protected virtual void Action(){

		GameObject menu = Instantiate(_menu,new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0),Quaternion.identity);
	}
	
}
