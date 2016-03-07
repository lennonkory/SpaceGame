using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the crosshair on the UI for the 
player's starting weapon. 
Resources: NA
*/

public class CrosshairUI : MonoBehaviour {
	
	public GUIStyle styleCross = new GUIStyle();
	public GUIStyle styleLaser = new GUIStyle();
	float height;
	float width;
	// Use this for initialization
	void Start () {
		styleCross.normal.textColor = Color.white;
		styleCross.fontSize = 20;
		styleLaser.normal.textColor = Color.white;
		styleLaser.fontSize = 5;

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
		height = gameObject.GetComponentInParent<Canvas>().pixelRect.height;
		width = gameObject.GetComponentInParent<Canvas>().pixelRect.width;


		GUI.Label (new Rect (width/2-5, height/2-10, 20, 20), "+",styleCross);
		GUI.Label (new Rect (width/2-7, height/2-10, 20, 20), "O",styleCross);
	}
}
