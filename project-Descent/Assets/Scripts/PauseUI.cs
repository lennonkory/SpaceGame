using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the Pause UI for the player.
It offers 4 choices:
Resume-unpauses the game
Restart-restarts the current level, the player will still 
	have their stats from when the level originally started
Main Menu-returns the player to the main menu
Quit-exits the game
Resources: NA
*/

public class PauseUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void activate()
	{
		Cursor.visible = true;
		this.enabled = true;
		Time.timeScale = 0;
		GetComponentInParent<Canvas> ().GetComponentInParent<MouseLook> ().enabled = false;
	}
	
	public void deactivate()
	{
		Cursor.visible = false;
		this.enabled = false;
		Time.timeScale = 1;
		GetComponentInParent<Canvas> ().GetComponentInParent<MouseLook> ().enabled = true;
	}
	

	
	// Update is called once per frame
	void Update () {
	
	}
	private float height;
	private float width;
	void OnGUI()
	{
		//GUIStyle buttonStyle = new GUIStyle();
		height = gameObject.GetComponentInParent<Canvas>().pixelRect.height;
		width = gameObject.GetComponentInParent<Canvas>().pixelRect.width;
		GUI.Box(new Rect(0,0,width,height),"");

		if (GUI.Button (new Rect (width / 2 - 50, height / 2 -25, 100, 50), "Restart")) {
			GetComponentInParent<Canvas>().GetComponentInParent<UIStateController>().pauseToggle();
			Destroy(GameObject.Find("Player"));
			Application.LoadLevel(Application.loadedLevel);
		}
		if (GUI.Button (new Rect (width / 2 - 50, height / 2 - 80, 100, 50), "Main Menu")) {
			GetComponentInParent<Canvas>().GetComponentInParent<UIStateController>().pauseToggle();
			Destroy(GameObject.Find("CarryOver"));
			Destroy(GameObject.Find("Player"));
			Application.LoadLevel(0);
		}

		if (GUI.Button (new Rect (width / 2 - 50, height / 2 - 135, 100, 50), "Resume")) {
			GetComponentInParent<Canvas>().GetComponentInParent<UIStateController>().pauseToggle();
		}
		if (GUI.Button (new Rect (width / 2 - 50, height / 2 + 30, 100, 50), "Quit")) {
			Application.Quit();
		}

	}
}
