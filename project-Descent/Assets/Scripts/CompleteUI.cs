using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the UI when the player completes a level.
It pauses the game and allows the player to either go to the next 
level or the main menu.
Resources: NA
*/

public class CompleteUI : MonoBehaviour {

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
	void OnGUI()
	{
		if (Application.loadedLevel == 5) {
						if (GUI.Button (new Rect (width / 2 - 50, height / 2 + 100, 100, 50), "Main Menu")) {
								Time.timeScale = 1;
								this.enabled = false;
								GameObject.Find ("Player").GetComponent<UIStateController> ().objectiveToggle ();
								try {
										Destroy (GameObject.Find ("CarryOver"));
								} catch {
								}
								Application.LoadLevel (0);
						}
			GUI.Label(new Rect(width/2-25,height/2-50,100,100),"You Win",style);
				}
		else{
		if (GUI.Button (new Rect (width/2-150, height/2+100, 100, 50), "Next Level")) {
			GameObject.Find("Player").transform.position= new Vector3(0,10,0);
			GameObject.Find("Player").GetComponent<MouseLook>().enabled=true;
			GetComponent<CompleteUI>().enabled=false;
			GameObject.Find("Player").GetComponentInChildren<Canvas>().GetComponentInChildren<UIDisplayHealth>().enabled=true;
			GameObject.Find("Player").GetComponent<PlayerController>().enabled=true;
			GameObject.Find ("Player").GetComponent<UIStateController>().objectiveToggle();
			PlayerStats stats = GameObject.Find("Player").GetComponent<PlayerStats>();
			stats.getPrim();
			stats.getSec();
			try{
					GameObject.Find("CarryOver").GetComponent<CarryOverStats>().setCarryOverStats(stats.getHealth(),stats.getEnergy(),stats.getMissleAmmo(),stats.getBombAmmo(),stats.getHomingAmmo(),stats.getFlyingAmmo(),stats.getArmor(),stats.usePrimList(), stats.useSecList());
			}
			catch{
				//print("Not good");
			}
			Time.timeScale=1;
			Application.LoadLevel(Application.loadedLevel+1);
		}
		if (GUI.Button (new Rect (width/2+50,height/2+100, 100, 50), "Main Menu")) {
			Time.timeScale =1;
			this.enabled=false;
			GameObject.Find("Player").GetComponent<UIStateController>().objectiveToggle();
			try{
				Destroy(GameObject.Find("CarryOver"));
			}
			catch{
			}
			Application.LoadLevel(0);
		}
			}
	}

}
