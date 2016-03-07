using UnityEngine;
using System.Collections;

/*
Author: Mitchell Cook
Function: This class handles the disrupted state for the player.
While the player has this state the DisruptedUI will be active.
Resources: NA
*/

public class DisruptedState : State {
	public float time;
	UIStateController state;
	public DisruptedState(float time){
		//stats = GetComponent<PlayerStats>();
		this.time = Time.time + time;
		state = GameObject.Find ("Player").GetComponent<UIStateController> ();
		//this.normUI = GameObject.Find ("UIDisplayHealth");

	}
	
	public string getState()
	{
		return "Disrupted";
	}

	public void updateState(State state)
	{
		this.time = Mathf.Max (this.time,((DisruptedState)state).time);
	}

	//true if applied
	//false if not
	public bool apply()
	{
		if (Time.time > this.time) {
			state.disruptedReset();
			return false;
				}

		state.disruptedSet ();

		return true;
	}
	public void removeState()
	{
		state.disruptedReset();

	}
}
