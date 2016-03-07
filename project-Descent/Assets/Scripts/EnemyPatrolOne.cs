using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Enemy class for patroling medium enemies, holding declaring/holding their stats, patrol and weapon set up.
Resources: StackOverflow.
*/

public class EnemyPatrolOne : Enemy {
	
	public override void Execute () 
	{
		health = 40;
		moveSpeed = 35;
		patrolSpeed = 10;
		rotationSpeed = 70;
		maxDistance = 100;
		attackRange = 75;

		patrol = true;
		nextPoint = 1;
		rotateTime = 0;
		
		weaponPrim = new Weapons(1,0,0.5f,0.8f,"CapsuleEnemy",0);
		weaponPrim.setAmmo (10000);
		primaryShot.gameObject.SetActive(true);
	}	
}
