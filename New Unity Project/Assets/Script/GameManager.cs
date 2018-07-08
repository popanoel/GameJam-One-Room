using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	Animator _monFadeur;
	static public GameManager instance;

	// Use this for initialization
	void Start () {
		_monFadeur=GameObject.Find("FADE").GetComponent<Animator>();
		instance=this;
	}

	public IEnumerator GameO(){
		_monFadeur.SetTrigger("GameOver");
		yield return new WaitForSeconds(1);
		SceneManageer.instance.GoTo("Main");
	}
}
