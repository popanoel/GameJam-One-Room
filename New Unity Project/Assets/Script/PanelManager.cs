using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

	[SerializeField]
	private List<Transform> targets;
	private int CurPanel = 1;

	//utilisée sous forme de référence avec SmoothDamp
	private Vector3 _velocity = Vector3.zero;
	private float _smoothTime = 0.3f;
	private Vector3 targetPosition;
	void Start()
	{
		targetPosition=transform.position;
	}


	public void goRight(){
		if(CurPanel == 4){
			CurPanel =1;
			transform.position = new Vector3(targets[0].position.x,transform.position.y,transform.position.z);
		}else{
			CurPanel+=1;		
		}
		
		targetPosition = new Vector3(targets[CurPanel].position.x,transform.position.y,transform.position.z);

	}
	public void goLeft(){
		if(CurPanel == 1){
			CurPanel =4;
			transform.position = new Vector3(targets[4].position.x,transform.position.y,transform.position.z);

		}else{
			CurPanel-=1;		
		}

		targetPosition = new Vector3(targets[CurPanel].position.x,transform.position.y,transform.position.z);

	}
	private void Update()
	{
		Vector3 newPos = Vector3.SmoothDamp(transform.position,targetPosition, ref _velocity,_smoothTime);
		
		transform.position = newPos;
		
	}
}
