using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {

	[SerializeField]
	private PersoManager.Char Mychef;

	[SerializeField]
	private GameObject _menu;
	private void Start()
	{
	}

	private void Update()
	{
		if(Input.GetMouseButtonUp(0)){
		}
	}
	void OnMouseUp()
	{
		AfficheMenu();
	}
	private void AfficheMenu(){

		GameObject menu = Instantiate(_menu,new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,Camera.main.ScreenToWorldPoint(Input.mousePosition).y,0),Quaternion.identity);
		//menu.transform.SetParent(GameObject.Find("Canvas").transform);
	}
	
}
