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
		switch(isDead){
				case PersoManager.Char.Amelia:Parler.Parleureur.Parle(isDead,"Wait, did you just… that gas… you didn’t, you little… I just want out of her! My revenge isn’t complete! Please! I beg… you… ");break;
				case PersoManager.Char.Bonnie:Parler.Parleureur.Parle(isDead,"The gas… I don’t understand… why pick me? I just… saved them… from the torment… I did what… I wish was done to me…");break;
				case PersoManager.Char.Bernard:Parler.Parleureur.Parle(isDead,"The gas… I see. I understand, I’m no angel. Please, just tell something to my boy… tell him… that I… ");break;
				case PersoManager.Char.Chips:Parler.Parleureur.Parle(isDead,"Seriously dude?! After that 5 minutes of wholesome bonding?! You gotta be kidding me. Just watch me, I’m gonna get reincarnated… and I’m… I’m going after you…");break;
			}
		yield return new WaitForSeconds(4);
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
