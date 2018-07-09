using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManageer : MonoBehaviour {

		public static SceneManageer instance;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(gameObject);
		if(instance!=null){
			Destroy(gameObject,0f);
		}else{
			instance=this;
		}
	}
	
	public void GoTo(string name){
		SceneManager.LoadScene(name);
	}

	public void Leavin(){
		Application.Quit();
	}
}
