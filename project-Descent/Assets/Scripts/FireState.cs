using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the fire state for the player and enemy.
It applies a variable damage over a variable time to the ship.
Resources: NA
*/


public class FireState : State {
	float damage;
	float time;
	float nextDamage;
	PlayerStats stats;
	EnemyAI statsE;

	public FireState(float damage, float time,PlayerStats stats){
		//stats = GetComponent<PlayerStats>();
		this.damage = damage;
		this.time = Time.time + time;
		this.stats = stats;
		this.statsE = null;
		nextDamage = Time.time + 1;
	}
	public FireState(float damage, float time,EnemyAI stats){
		//stats = GetComponent<PlayerStats>();
		this.damage = damage;
		this.time = Time.time + time;
		this.statsE = stats;
		this.stats = null;
		nextDamage = Time.time + 1;
	}

	public void updateState(State state)
	{
		return;
		}

	public string getState()
	{
		return "Fire";
	}
	//true if applied
	//false if not
	public bool apply()
	{
		if (Time.time > this.time) {
			return false;
				}
		if (Time.time>nextDamage)
		{
			nextDamage = Time.time+1;
			if (statsE==null)
			{
			if (stats.loseHealth(damage)==false)
			{
				Application.LoadLevel(Application.loadedLevel);
			}
			}
			else{
				statsE.ApplyDamage((int)damage);
			}
		}

		return true;
	}
	public void removeState()
	{
		return;
	}
}
