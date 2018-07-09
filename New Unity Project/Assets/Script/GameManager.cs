using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour {

	private Animator _monFadeur;
	static public GameManager instance;
	private GameObject _menuPause;
	private GameObject _menuContainer;
	public bool _isPaused=false;
	// Use this for initialization
	public bool _isEnding=false;
	[SerializeField]
	private Transform _lePanneau;
	void Start () {
		instance=this;
		_monFadeur=GameObject.Find("FADE").GetComponent<Animator>();
		_menuPause=Resources.Load<GameObject>("PauseScreen");
	}

	public IEnumerator GameO(PersoManager.Char isDead){
		_monFadeur.SetTrigger("GameOver");
		yield return new WaitForSeconds(1);
		if(isDead==PersoManager.Char.Me){
			SceneManageer.instance.GoTo("GameOver");
		}else{
			SceneManageer.instance.GoTo("Dead"+isDead.ToString());
		}
	}

	/// <summary>
	/// Update is called every frame, if the MonoBehaviour is enabled.
	/// </summary>
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape)){
			TogglePause();
		}
	}

	public void Ending(){
		_isEnding=true;
		_lePanneau.position=new Vector3(_lePanneau.position.x,_lePanneau.position.y+1.4f,_lePanneau.position.z);

	}
	public void Fin(){
		StartCoroutine(GameO(PersoManager.getCurrentChar));
	}
	public void TogglePause(){
		_isPaused=!_isPaused;
		if(_isPaused){
			GameObject.Find("Canvas").transform.Find("PauseScreen").gameObject.SetActive(true);
		//	_menuContainer=Instantiate(_menuPause,GameObject.Find("Canvas").transform.position,Quaternion.identity,GameObject.Find("Canvas").transform);
		}else{
			GameObject.FindGameObjectsWithTag("PauseScreen")[0].SetActive(false);
		}
	}
}
