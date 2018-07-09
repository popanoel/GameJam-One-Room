using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour {

	[SerializeField]
	private Texture2D _cursor;

	[SerializeField]
	private Texture2D _cursorHighligth;

	public static CursorManager instance;
	
	private bool _isHigh=false;
	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(gameObject);
		if(instance!=null){
			Destroy(gameObject,0f);
		}else{
			instance=this;
		}
		
		Cursor.SetCursor(_cursor,new Vector2(_cursorHighligth.width/2,_cursorHighligth.height/2),CursorMode.Auto);
	}
	
	public void ToggleCursor(){
		_isHigh=!_isHigh;
		if(_isHigh){
			Cursor.SetCursor(_cursorHighligth,new Vector2(_cursorHighligth.width/2,_cursorHighligth.height/2),CursorMode.Auto);
		}else{
			Cursor.SetCursor(_cursor,new Vector2(_cursorHighligth.width/2,_cursorHighligth.height/2),CursorMode.Auto);
			StopAllCoroutines();
		}
	}

}
