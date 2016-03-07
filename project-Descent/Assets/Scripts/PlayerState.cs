using UnityEngine;
using System.Collections;
/*
Author:Mitchell Cook
Function: This class holds the state of the player. It also 
applies any effects those states have onto the player, with 
the exception of 'Stunned'. Since stunned does not apply anything 
onto the player but instead makes the player unable to move(change velocity), 
stunned is handled in "CharacterMovement2"
Resources: NA
 */
public class PlayerState : MonoBehaviour {
	
	private PlayerStats stats;
	private bool stunned=false;
	private float stunnedTime=0.0f;
	private string[,] stateList = new string[15,3];
	//private Queue<int> stateList = new Queue<int>;
	

	public string [] getStates()
	{
		string [] results = new string [15]; 
		int counter = 0;
		if (stunned) {
			results[0]="Stunned";
			counter ++;
		}
		for (int i =0; i<15; i++) {
			if (stateList[i,0]!="None")
			{
				results[counter] = stateList[i,0];
				counter++;
			}
		}
		return results;
	}

	// Use this for initialization
	void Start () {
		stats = GetComponent<PlayerStats> ();
		for (int i=0; i<15; i++) {
			stateList[i,0]="None";
			stateList[i,1]="0";
			stateList[i,2]="0";
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (stunned) {
			if (stunnedTime<Time.time)
			{
				stunned=false;
			}
		}
		bool disruptedFound = false;
		for (int i=0; i<15; i++) {
			if (float.Parse(stateList[i,1],
			                System.Globalization.CultureInfo.InvariantCulture)<Time.time)
			{
				/*if (stateList[i,0]=="disrupted")
				{
					GetComponentInChildren<Canvas>().GetComponentInChildren<UIDisplayHealth>().enabled = !GetComponentInChildren<Canvas>().GetComponentInChildren<UIDisplayHealth>().enabled;
					GetComponentInChildren<Canvas>().GetComponentInChildren<UIDisrupted>().enabled = !GetComponentInChildren<Canvas>().GetComponentInChildren<UIDisrupted>().enabled;
				}*/
				stateList[i,0]="None";
			}
			if (stateList[i,0]=="disrupted")
				disruptedFound=true;

			if (stateList[i,0]=="fire" && float.Parse(stateList[i,2],
			                                          System.Globalization.CultureInfo.InvariantCulture)<Time.time)
			{
				stats.loseHealth(2);
				stateList[i,2]=(Time.time+1).ToString();
			}

		}
		if (!disruptedFound) {
			GetComponentInChildren<Canvas>().GetComponentInChildren<UIDisplayHealth>().enabled = true;
			GetComponentInChildren<Canvas>().GetComponentInChildren<UIDisrupted>().enabled = false;
		
				}
	}
	
	public bool isStunned()
	{
		return stunned;
	}

	//public void addDefaultFireState()



	public void addState(string state, float time)
	{
		if (state == "disrupted") {
			GetComponentInChildren<Canvas>().GetComponentInChildren<UIDisplayHealth>().enabled = false;
			GetComponentInChildren<Canvas>().GetComponentInChildren<UIDisrupted>().enabled = true;
		}
		if (state == "stunned") {
						stunned = true;
						stunnedTime = Time.time + time;
		} 
		else 
		{
			for (int i=0;i<15;i++)
			{
				if (stateList[i,0]=="None")
				{
					stateList[i,0]=state;
					stateList[i,1]=(Time.time+time).ToString();
					stateList[i,2]=(Time.time).ToString();
					return;
				}
			}
		}
	}
}
