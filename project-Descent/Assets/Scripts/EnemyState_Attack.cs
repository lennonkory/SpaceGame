using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: If enemy is insight and in attack range, fire weapon.
Resources: StackOverflow.
*/

public class EnemyState_Attack : EnemyState {
	
	public RaycastHit hit;

	public override void Execute(EnemyAI enemyunit){
		//checking if no objects are inbetween enemy and player
		if (Physics.Raycast (enemyunit.myTransform.position, enemyunit.myTransform.forward, out hit, enemyunit.enemyHold.attackRange)) {

			//if object in line of sight is the player
			if (hit.transform == enemyunit.target) {

				//fire weapon when ready to fire
				if (Time.time > enemyunit.enemyHold.weaponPrim.nextFire) {
					enemyunit.enemyHold.weaponPrim.nextFire = Time.time + enemyunit.enemyHold.weaponPrim.fireRate;
					MonoBehaviour.Instantiate (enemyunit.enemyHold.primaryShot, enemyunit.enemyHold.shotSpawn.position, enemyunit.enemyHold.shotSpawn.rotation);
				}
			}
		}
	}

	public override void ExecuteBoss(EnemyBossAI enemyunit){
		//Not needed
	}
}

