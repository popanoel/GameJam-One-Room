using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public static GameManager instance;
void Start()
{
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
