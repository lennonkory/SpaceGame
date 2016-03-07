using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the stunned state for the player.
This state tells the player's movement class, CharacterMovement2, 
that it is stunned. after the effect ends it tells it that the 
player is no longer stunned.  
Resources: NA
*/


public class StunnedState : State {
	public float time;
	GameObject movement;
	public StunnedState(float time){
		this.time = Time.time + time;
		movement = GameObject.Find ("Player");
	}

	public string getState()
	{
		return "Stunned";
	}
	 
	public void updateState(State state)
	{
		this.time = Mathf.Max (((StunnedState)state).time, this.time);
	}

	//true if applied
	//false if not
	public bool apply()
	{
		if (Time.time > this.time) {
			movement.GetComponent<CharacterMovement2>().stunned=false;

			return false;
		}
		movement.GetComponent<CharacterMovement2>().stunned=true;
		
		return true;
	}
	public void removeState()
	{
		movement.GetComponent<CharacterMovement2>().stunned=false;

	}
}
