using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the disrupted UI for the player.
While the player is disrupted the screen will fill with random 
characters and the current health, energy and ammo will be unreadable.
Resources: NA
*/
public class UIDisrupted : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	float refreshTime=0;

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
		//if (refreshTime > Time.time)
	//		return;
	//	refreshTime = Time.time;
		//disruptedGUI ();
	}
	int num = 0;
	int[] randWidth = new int[200];
	int [] randHeight = new int [200];
	char[] randChar = new char[200];
	char[] randHealth = new char[10];
	char[] randEnergy = new char[20];
	char[] randAmmo = new char[20];
	char[][] randState = new char[20][]; 
	GUIStyle[] style = new GUIStyle[200];
	void Awake()
	{
		for (int i=0; i<20; i++)
						randState [i] = new char[20];
		for (int i =0; i<200; i++)
						style [i] = new GUIStyle ();
	}

	void OnGUI()
	{	

		int height = (int)gameObject.GetComponentInParent<Canvas>().pixelRect.height;
		int width = (int)gameObject.GetComponentInParent<Canvas>().pixelRect.width;
/*		int stateCounter = 0;
		stateList= state.getStates();
		print (stateList);
		for (int i=0; i<state.getStates().Length; i++) {
			if (stateList[i]!="None")
			{
				stateCounter++;
			}
				}
		for (int i =0; i<stateCounter; i++) {
			for (int j =0;j<20;j++)
			{
				randState[i][j]=(char)Random.Range (32, 126);
			}
		}
		string tempBuffer="";
		for (int i=0; i<stateCounter; i++) {
			for (int j=0;j<20;j++)
				tempBuffer=tempBuffer+randState[i][j];
			GUI.Label(new Rect(width-75,10+10*i,100,100),tempBuffer);
			tempBuffer="";
				}*/
		if (refreshTime < Time.time) {
						num = Random.Range (100, 200);
						for (int i = 0; i<num; i++){
							randWidth [i] = Random.Range (0, width);
							randHeight [i] = Random.Range (0, height);
							randChar [i] = (char)Random.Range (33, 126);
							style[i].normal.textColor = new Color(Random.Range(0.0f, 0.5f), Random.Range(0.0f, 0.5f), Random.Range(0.0f, 0.5f), 1.0f);
			}
				for (int i =0;i<10;i++)
				{
				randHealth[i]=(char)Random.Range(32,126);}
				for (int i =0;i<20;i++){
					randEnergy[i]=(char)Random.Range(32,126);
					randAmmo[i]=(char)Random.Range(32,126);
				}

			refreshTime=Time.time+0.15f;
				}
		for (int i =0; i<num; i++) {
			GUI.Label(new Rect(randWidth[i],randHeight[i],100,100),randChar[i].ToString(),style[i]);
				}

		//health:000
		string bufferH = "";
		string bufferE = "";
		string bufferA = "";

		for (int i =0; i<10; i++) {
						bufferH = bufferH + randHealth [i];
				}
			for (int i =0; i<20; i++) {
				bufferA=bufferA+randAmmo[i];
			bufferE=bufferE+randEnergy[i];

				}
		GUI.Label (new Rect (0, height-20, 75, 20),bufferH);
		GUI.Label (new Rect (width-90-(10*7), height-40, 75+1000, 20),bufferE );
		GUI.Label (new Rect (width-92-(10*7), height-20, 75+1000, 20), bufferA);

		//energy:000
		//ammo:000
	}
}
