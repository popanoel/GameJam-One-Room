using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrisonManager : MonoBehaviour {

	public enum Prison {c0,c1,c2,c3,None};

	static private Prison CurrentPrison;

	private GameObject _monAffichage;
	// Use this for initialization
	void Start () {
		CurrentPrison=Prison.c0;
		_monAffichage=GameObject.Find("Prison");
		
		
	}
	public void PrisonChange(Prison newPrison){

		_monAffichage.transform.Find(CurrentPrison.ToString()).gameObject.SetActive(false);
		_monAffichage.transform.Find(newPrison.ToString()).gameObject.SetActive(true);

		CurrentPrison=newPrison;
		
	}
	static public Prison getCurrentPrison{
		get{
			return CurrentPrison;
		}
		set{
			CurrentPrison=value;
		}
	}
}
