using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the crosshair for the Fire primary weapon. 
Resources: NA
*/
public class Weapon1PrimCH : MonoBehaviour {

	public GUIStyle style = new GUIStyle();
	float height;
	float width;

	public void activate()
	{
		this.enabled = true;
	}
	
	public void deactivate()
	{
		this.enabled = false;
	}

	// Use this for initialization
	void Start () {
		height = gameObject.GetComponentInParent<Canvas>().pixelRect.height;
		width = gameObject.GetComponentInParent<Canvas>().pixelRect.width;
		style.normal.textColor = Color.white;
		style.fontSize = 20;

	}

	
	// Update is called once per frame
	void Update () {
	
	}
	void OnGUI()
	{
		GUI.Label (new Rect (width / 2-5, height / 2-10, 10, 10), "x",style);
	}
}
