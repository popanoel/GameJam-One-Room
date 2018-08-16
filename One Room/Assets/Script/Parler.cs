using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Parler : MonoBehaviour {
	static public Parler Parleureur;
	private Text _monText;
	private Image _maVignette;
	[SerializeField]
	private List<Sprite> _vignettes;

	private void Start(){
		_monText=transform.Find("Parole").GetComponent<Text>();
		_maVignette=transform.Find("Vignette").GetComponent<Image>();

		Parleureur=this;
	}
	public void Parle(PersoManager.Char parleur,string ceQuiDit){
		_monText.text=ceQuiDit.ToUpper();
				var colorHolder=_maVignette.color;

				colorHolder.a=1f;
				_maVignette.color=colorHolder;
		//ICI ON PLACE LA FACE DU GARS
		switch(parleur){
			case PersoManager.Char.Amelia:
				_maVignette.sprite=_vignettes[1];
				break;
			case PersoManager.Char.Bonnie:
				_maVignette.sprite=_vignettes[0];
				break;
			case PersoManager.Char.Bernard:
				_maVignette.sprite=_vignettes[2];
				break;
			case PersoManager.Char.Chips:
				_maVignette.sprite=_vignettes[3];
				break;
			default:
				colorHolder.a=0f;
				_maVignette.color=colorHolder;
				break;
		}

		StopCoroutine("Discute");
		transform.position=new Vector3(transform.position.x,80,transform.position.z);
		StartCoroutine("Discute");
	}

	IEnumerator Discute(){
	/**	while(true){
			if(Input.GetMouseButtonDown(0)){
				transform.position=new Vector3(transform.position.x,-60,transform.position.z);
				yield return null;
			}
			yield return new WaitForEndOfFrame();
		} **/
		
		//cheker pour attendre un nombre de sec ou click
		yield return new WaitForSeconds(5);
		transform.position=new Vector3(transform.position.x,-80,transform.position.z);
		_monText.text="";
	}

}
