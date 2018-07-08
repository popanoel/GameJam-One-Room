using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleFiche : MonoBehaviour {

	[SerializeField]
	private PersoManager.Char _maCible;

	/// <summary>
	/// OnMouseUp is called when the user has released the mouse button.
	/// </summary>
	void OnMouseUp()
	{
		if(_maCible == PersoManager.Char.None){
			transform.parent.parent.Find("Computer").gameObject.SetActive(true);
		}else{
			transform.parent.parent.Find(_maCible.ToString()).gameObject.SetActive(true);
		}
			transform.parent.gameObject.SetActive(false);
	}


}
