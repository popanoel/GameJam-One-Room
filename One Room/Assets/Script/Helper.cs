using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper {

	public static Vector2 cameraSize{
		get{
			return GetCameraSize();
		}
	}

	private static Vector2 GetCameraSize(){		
		float hauteur = Camera.main.orthographicSize * 2;
		float largeur =  hauteur * Camera.main.aspect;

		return new Vector2(largeur, hauteur);
	}

}
