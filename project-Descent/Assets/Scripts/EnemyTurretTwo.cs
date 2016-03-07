using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Enemy homing missle class for static enemies, holding declaring/holding their stats, patrol and weapon set up.
Resources: StackOverflow.
*/

public class EnemyTurretTwo : Enemy {
	
	public override void Execute () 
	{
		health = 30;
		moveSpeed = 0;
		patrolSpeed = 0;
		rotationSpeed = 40;
		maxDistance = 120;
		attackRange = 120;
		patrol = false;
		
		weaponPrim = new Weapons(1,0,4.0f,6.0f,"HomingEnemy",0);
		weaponPrim.setAmmo (10000);
		primaryShot.gameObject.SetActive(true);
	}	
}
