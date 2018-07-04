using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersoManager : MonoBehaviour {

	public enum Char {Bonnie,Amelia,Bernard,Chips,Joachim,None};

	private Char CurrentChar=Char.None;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public Char getCurrentChar{
		get{
			return CurrentChar;
		}
		set{
			CurrentChar=value;
		}
	}
}