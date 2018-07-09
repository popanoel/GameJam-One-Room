using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichePersoOrdi : MonoBehaviour {
	private Vector3 _startPoint;
	private Vector3 _dragPoint;
	private float _maxHaut=-8f;
	private float _maxBas=6.7f;
	private float _deltaY;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
  			_startPoint =Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 currentPos=transform.position;
			_deltaY=currentPos.y-_startPoint.y;
		
	}
	void OnMouseDrag(){
		_dragPoint=Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	transform.position = new Vector3(0,Mathf.Clamp(_dragPoint.y+_deltaY,_maxHaut,_maxBas),0);
		
	}
	private void OnMouseUp(){
  		_startPoint =Vector3.zero;
	}
}
