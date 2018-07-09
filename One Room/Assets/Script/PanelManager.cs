using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour {

	[SerializeField]
	private List<GameObject> _mesEnfants;

	private int CurPanel = 0;

	private void Start()
	{
		CurPanel=0;
	}
	public void goRight(){
		
		_mesEnfants[CurPanel].SetActive(false);
		if(CurPanel==4){
			CurPanel=1;
		}else if(CurPanel>=3){
			CurPanel=0;
		}else{
			CurPanel+=1;
		}
		_mesEnfants[CurPanel].SetActive(true);
	}

	public void goLeft(){
		_mesEnfants[CurPanel].SetActive(false);
		if(CurPanel==4){
			CurPanel=1;
		}else if(CurPanel<=0){
			CurPanel=3;
		}else{
			CurPanel-=1;
		}
		_mesEnfants[CurPanel].SetActive(true);
	}

	public void toggleFinal(){

		_mesEnfants[4].SetActive(!_mesEnfants[4].activeSelf);
		_mesEnfants[CurPanel].SetActive(!_mesEnfants[CurPanel].activeSelf);
		CurPanel=4;
	}
}
