using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the UI for the main menu.
It offers 3 choices: 
Start-begins the game at level 1
Level Select-lets the player choose a level to start from
Quit-exits the game
Resources: NA
*/

public class MainMenuUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		width = gameObject.GetComponentInParent<Canvas> ().pixelRect.width;

	}
	
	// Update is called once per frame
	void Update () {
	
	}
	float width;
	bool levelS=false;

	void OnGUI()
	{
		Cursor.visible = true;
		if (levelS == false) {
			if (GUI.Button (new Rect (width / 2 - 50, 0, 100, 50), "Start")) {
				Application.LoadLevel (1);
			}
			if (GUI.Button (new Rect (width / 2 - 50, 55, 100, 50), "Level Select")) {
				levelS = true;
			}
			if (GUI.Button (new Rect (width / 2 - 50, 110, 100, 50), "Quit")) {
				Application.Quit ();
			}
		} 
		else {
			if (GUI.Button(new Rect(width/2-50,0,100,50),"Level 1:\n "))
			{
				Application.LoadLevel(1);
			}
			if (GUI.Button(new Rect(width/2-50,50,100,50),"Level 2:\n "))
			{
				Application.LoadLevel(2);
			}
			if (GUI.Button(new Rect(width/2-50,100,100,50),"Level 3:\n "))
			{
				Application.LoadLevel(3);
			}
			if (GUI.Button(new Rect(width/2-50,150,100,50),"Level 4:\n "))
			{
				Application.LoadLevel(4);
			}
			if (GUI.Button(new Rect(width/2-50,200,100,50),"Level 5:\n "))
			{
				Application.LoadLevel(5);
			}
		}
	}
}
