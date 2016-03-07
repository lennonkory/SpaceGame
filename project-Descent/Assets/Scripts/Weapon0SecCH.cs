using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the crosshair for the starting secondary weapon. 
Resources: NA
*/

public class Weapon0SecCH : MonoBehaviour {
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

	void OnGUI ()
	{
		//GUI.Label (new Rect (width / 2-5 - 12, height / 2 + 50, 20, 20), ">",style);
		//GUI.Label (new Rect (width / 2 -5 + 12, height / 2 + 50, 20, 20), "<",style);
		GUI.Label (new Rect (width / 2 - 25, height / 2 + 50, 20, 20), "_____", style);
		GUI.Label (new Rect (width / 2 - 20, height / 2 + 35, 20, 20), "____", style);
		GUI.Label (new Rect (width / 2 - 15, height / 2 + 20, 20, 20), "___", style);
		GUI.Label (new Rect (width / 2 - 10, height / 2 + 5, 20, 20), "__", style);
		GUI.Label (new Rect (width / 2 - 5, height / 2 -10, 20, 20), "_", style);
	}
}
