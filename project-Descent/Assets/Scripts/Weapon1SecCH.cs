using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the crosshair for the Bomb secondary weapon. 
Resources: NA
*/
public class Weapon1SecCH : MonoBehaviour {

	public GUIStyle style = new GUIStyle();
	float height;
	float width;
	
	// Use this for initialization
	void Start () {
		height = gameObject.GetComponentInParent<Canvas>().pixelRect.height;
		width = gameObject.GetComponentInParent<Canvas>().pixelRect.width;
		style.normal.textColor = Color.white;
		style.fontSize = 20;
		
	}

	public void activate()
	{
		this.enabled = true;
	}
	
	public void deactivate()
	{
		this.enabled = false;
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Label (new Rect (width/2-2-2,height/2+5,20,20),"\\",style);
		GUI.Label (new Rect (width/2-2+2,height/2+5,20,20),"/",style);
	}

}
