using UnityEngine;
using System.Collections;


/*
Author:Kory Bryson
Function: Determines if all enemies have been killed. When an enemy dies it sends a message to Objective which updates the active
objective. This completes the requirenment for having one objective.
Resources: NA
*/


[System.Serializable]
public class KillAllEnemies : ActiveObjective {

	public GameObject[] enemies;

	public KillAllEnemies()
	{
		TaskCompleted = false;
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
	}

	override public string ObjectiveMessage()
	{
		return ("Kill All Enemies");
	}


	override public void UpdateOb()
	{

		if (GameObject.FindGameObjectsWithTag ("Enemy").Length == 0)
		{
			AllEnemiesDead();
		}

	}

	public void AllEnemiesDead()
	{
		TaskCompleted = true;
	}
	
}
