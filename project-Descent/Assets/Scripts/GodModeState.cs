using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the invincibility state of the player.
While the player is invincible they will not take damage form any source.
this is handled in the PlayerStats class while invincibility is true.
Resources: NA
*/


public class GodModeState : State {
	public float time;
	PlayerStats stats;
	PlayerState2 state;
	public GodModeState(float time){
		//stats = GetComponent<PlayerStats>();
		this.time = Time.time + time;
		this.stats = GameObject.Find ("Player").GetComponent<PlayerStats> ();
		this.state = GameObject.Find ("Player").GetComponent<PlayerState2> ();

	}
	
	public string getState()
	{ 
		return "GodMode";
	}
	//true if applied
	//false if not
	
	public void updateState(State state)
	{
		this.time = Mathf.Max (((GodModeState)state).time, this.time);
	}
	
	public bool apply()
	{
		if (Time.time > this.time) {
			stats.godMode = false;
			state.godMode = false;
			return false;
		}
		stats.godMode = true;
		//state.GodMode ();
		return true;
	}
	public void removeState()
	{
		stats.godMode = false;
		state.godMode = false;

	}
}
