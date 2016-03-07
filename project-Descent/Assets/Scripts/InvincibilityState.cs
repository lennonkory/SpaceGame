using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the invincibility state of the player.
While the player is invincible they will not take damage form any source.
this is handled in the PlayerStats class while invincibility is true.
Resources: NA
*/


public class InvincibilityState : State {
	public float time;
	PlayerStats stats;
	public InvincibilityState(float time){
		//stats = GetComponent<PlayerStats>();
		this.time = Time.time + time;
		this.stats = GameObject.Find ("Player").GetComponent<PlayerStats> ();

	}
	
	public string getState()
	{ 
		return "Invincibility";
	}
	//true if applied
	//false if not
	
	public void updateState(State state)
	{
		this.time = Mathf.Max (((InvincibilityState)state).time, this.time);
	}
	
	public bool apply()
	{
		if (Time.time > this.time) {
			stats.invincibility = false;
			return false;
		}
		stats.invincibility = true;
		return true;
	}
	public void removeState()
	{
		stats.invincibility = false;
	}
}
