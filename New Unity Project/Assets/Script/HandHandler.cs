using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandHandler : MonoBehaviour {


	private GameObject _maMain;
	// Use this for initialization
	void Start () {
		_maMain=GameObject.Find("Main");
	}
	
	private void OnMouseEnter()
	{
		_maMain.transform.position=new Vector3(_maMain.transform.position.x,GameObject.Find("Canvas").transform.position.y,_maMain.transform.position.z);
	}

	private void OnMouseExit()
	{
		_maMain.transform.position=new Vector3(_maMain.transform.position.x,-1000,_maMain.transform.position.z);
	}

}
