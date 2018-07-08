using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FichePersoOrdi : MonoBehaviour {
	private Vector3 _startPoint;
	private Vector3 _dragPoint;
	private float _maxHaut=-6.3f;
	private float _maxBas=6.7f;
	private float _deltaY;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	/// <summary>
	/// OnMouseDown is called when the user has pressed the mouse button while
	/// over the GUIElement or Collider.
	/// </summary>
	void OnMouseDown(){
  			_startPoint =Camera.main.ScreenToWorldPoint(Input.mousePosition);
			Vector3 currentPos=transform.position;
			_deltaY=currentPos.y-_startPoint.y;
		
	}
	void OnMouseDrag(){
		_dragPoint=Camera.main.ScreenToWorldPoint(Input.mousePosition);
    	transform.position = new Vector3(0,Mathf.Clamp(_dragPoint.y+_deltaY,_maxHaut,_maxBas),0);
		
	}
}
