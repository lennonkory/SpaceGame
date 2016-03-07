using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Moves enemy closer to player's position when not in attacking distance.
*/

public class EnemyState_Cautious : EnemyState {

	public RaycastHit hit;

	public override void Execute(EnemyAI enemyunit){
		//checking if no objects are inbetween enemy and player
		if (Physics.Raycast (enemyunit.myTransform.position, enemyunit.myTransform.forward, out hit, enemyunit.enemyHold.maxDistance)) {
			
			//if object in line of sight is the player
			if (hit.transform == enemyunit.target) {
				//Move towards target when not in attacking distance
				enemyunit.myTransform.position += enemyunit.myTransform.forward * enemyunit.enemyHold.moveSpeed * Time.deltaTime;
			}
		}
	}

	public override void ExecuteBoss(EnemyBossAI enemyunit){
		//checking if no objects are inbetween boss and player
		if (Physics.Raycast (enemyunit.myTransform.position, enemyunit.myTransform.forward, out hit, enemyunit.enemyHold.maxDistance)) {
			
			//if object in line of sight is the player
			if (hit.transform == enemyunit.target) {
				//Move towards target when not in attacking distance
				enemyunit.myTransform.position += enemyunit.myTransform.forward * enemyunit.enemyHold.moveSpeed * Time.deltaTime;
			}
		}
	}
}
