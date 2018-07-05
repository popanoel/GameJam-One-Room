using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup : MonoBehaviour {


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}
	void OnMouseExit(){
		Debug.Log("kill him");
		Destroy(this.gameObject,0f);
	}


	public void Inspect(){
		Debug.Log("inspect");
	}
	public void Interact(){
		Debug.Log("interact");
	}
}
