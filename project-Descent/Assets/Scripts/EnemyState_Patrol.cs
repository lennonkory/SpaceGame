using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Moves enemy on a patrol route at it's patrol speed.
Resources: StackOverflow.
*/

public class EnemyState_Patrol : EnemyState {

	float distance;
    
	public override void Execute(EnemyAI enemyunit){
		//distance from desired point
		distance = Vector3.Distance(enemyunit.myTransform.position, enemyunit.enemyHold.currentPoint);

		if (distance < 5) {
			if (enemyunit.enemyHold.nextPoint == 1) {
				enemyunit.enemyHold.nextPoint = 2;
				enemyunit.enemyHold.currentPoint = enemyunit.enemyHold.startingPoint;   
			} else {
				enemyunit.enemyHold.nextPoint = 1;
				enemyunit.enemyHold.currentPoint = enemyunit.enemyHold.rallyPoint;
			}

			//rotate enemy to face new rally point
			enemyunit.myTransform.LookAt (enemyunit.enemyHold.currentPoint);
			enemyunit.enemyHold.rotateTime = Time.time + 1.0f;

		} else {
			//delay when rotate
			if(Time.time > enemyunit.enemyHold.rotateTime) {
				enemyunit.myTransform.position += enemyunit.myTransform.forward * enemyunit.enemyHold.patrolSpeed * Time.deltaTime;
			}
		}
	}

	public override void ExecuteBoss(EnemyBossAI enemyunit){
		//Not needed
	}
}
