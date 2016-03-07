using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: A game world object that determines which objective that player is trying to complete. To complete the alpha we needed
one objective. For the RC there are now 2 objectives, kill all enemies and find the ball
Resources: NA
 */

public class Objective : MonoBehaviour
{

	public ActiveObjective objective;
	private float nextCheck;

	// Use this for initialization
	void Start () 
	{
		nextCheck =  3f;
		if(Application.loadedLevelName == "SecondStage" || Application.loadedLevelName == "ThirdStage"){
			objective = new FindTheBall ();
		}
		else{
			objective = new KillAllEnemies ();
		}
	}
	
	float nextLevelTime;
	// Update is called once per frame
	void Update () 
	{

		if(Time.time > nextCheck)
		{

			objective.UpdateOb ();

			if (objective.checkCompletion())
			{
				//print ("It's game over MAN!!");
				GameObject.Find("Player").GetComponent<UIStateController>().objectiveToggle();
				/*
				GameObject.Find("Player").GetComponent<MouseLook>().enabled=false;
				GameObject.Find("Player").GetComponent<PlayerController>().enabled=false;
				GameObject.Find("Player").GetComponentInChildren<Canvas>().GetComponentInChildren<CompleteUI>().enabled=true;
				GameObject.Find("Player").GetComponentInChildren<Canvas>().GetComponentInChildren<UIDisplayHealth>().enabled=false;
				Time.timeScale=0;
				*/
				//GameObject.Find("Player").transform.position= new Vector3(0,10,0);
				//Application.LoadLevel(2);

			}
			nextCheck = Time.time + 2f;
		}



	}
	public bool getCompleted()
	{
		return objective.checkCompletion ();
	}

}
