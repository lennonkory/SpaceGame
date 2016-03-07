using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: This abstract class is the parent class for Active objectives (the objective the player is tring to complete).
It is very basic now and as new objectives are create it will expand. Its function is to check if the objective has been completed
Resources: NA
 */


public abstract class ActiveObjective
{

	private bool tastCompleted;

	/*I decide to use some C# style*/
	public bool TaskCompleted
	{
		get { return tastCompleted; }
		set { tastCompleted = value; }
	}

	public abstract void UpdateOb();

	public abstract string ObjectiveMessage ();
	
	/*Checks if the Objective has been completted*/
	public bool checkCompletion()
	{

		return TaskCompleted;

	}
}
