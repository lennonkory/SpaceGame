using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: If enemy is insight and in attack range, fire all weapons.
Resources: StackOverflow.
*/

public class EnemyState_MultiAttack : EnemyState {
	
	public RaycastHit hit;
	
	public override sealed void ExecuteBoss(EnemyBossAI enemyunit){
		//checking if no objects are inbetween enemy and player
		if (Physics.Raycast (enemyunit.myTransform.position, enemyunit.myTransform.forward, out hit, enemyunit.enemyHold.attackRange)) {
			
			//if object in line of sight is the player
			if (hit.transform == enemyunit.target) {

				//fire weapon when ready to fire
				if(Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, enemyunit.myTransform.position) < enemyunit.enemyHold.bombRange) {
					if (Time.time > enemyunit.enemyHold.weaponPrim.nextFire) {
						enemyunit.enemyHold.weaponPrim.nextFire = Time.time + enemyunit.enemyHold.weaponPrim.fireRate;
						MonoBehaviour.Instantiate (enemyunit.enemyHold.primaryShot, enemyunit.enemyHold.shotSpawn.position, enemyunit.enemyHold.shotSpawn.rotation);
					}
				}

				//fire weapon when ready to fire
				if (Time.time > enemyunit.enemyHold.weaponPrim2.nextFire) {
					enemyunit.enemyHold.weaponPrim2.nextFire = Time.time + enemyunit.enemyHold.weaponPrim2.fireRate;
					MonoBehaviour.Instantiate (enemyunit.enemyHold.primaryShot2, enemyunit.enemyHold.shotSpawn2.position, enemyunit.enemyHold.shotSpawn2.rotation);
				}

				//fire weapon when ready to fire
				if (Time.time > enemyunit.enemyHold.weaponPrim3.nextFire) {
					enemyunit.enemyHold.weaponPrim3.nextFire = Time.time + enemyunit.enemyHold.weaponPrim3.fireRate;
					MonoBehaviour.Instantiate (enemyunit.enemyHold.primaryShot3, enemyunit.enemyHold.shotSpawn3.position, enemyunit.enemyHold.shotSpawn3.rotation);
				}

				//fire weapon when ready to fire
				if (Time.time > enemyunit.enemyHold.weaponPrim4.nextFire) {
					enemyunit.enemyHold.weaponPrim4.nextFire = Time.time + enemyunit.enemyHold.weaponPrim4.fireRate;
					MonoBehaviour.Instantiate (enemyunit.enemyHold.primaryShot4, enemyunit.enemyHold.shotSpawn4.position, enemyunit.enemyHold.shotSpawn4.rotation);
				}

			}
		}
	}

	public override void Execute(EnemyAI enemyunit) { 
		//not needed
	}
}

