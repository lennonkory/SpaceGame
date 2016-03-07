using UnityEngine;
using System.Collections;


/*
Author:Kory Bryson
Function: Determines if the player has captured the ball (flew into it)
objective. This completes the requirement for having more than one objective.
Resources: The ball model was taken from https://www.assetstore.unity3d.com/en/#!/content/446
*/


[System.Serializable]
public class FindTheBall : ActiveObjective {

	
	public FindTheBall()
	{
		TaskCompleted = false;

	}
	
	override public string ObjectiveMessage()
	{
		return ("Find the Ball");
	}
	
	
	override public void UpdateOb()
	{
		
		if (GameObject.FindGameObjectsWithTag ("TheBall").Length == 0)
		{
			BallFound();
		}
		
	}
	
	public void BallFound()
	{
		TaskCompleted = true;
	}
	
}
