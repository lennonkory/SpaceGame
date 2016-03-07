using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Enemy class for medium size enemies, holding declaring/holding their stats, patrol and weapon set up.
Resources: StackOverflow.
*/

public class EnemyOne : Enemy {
	
	public override void Execute () 
	{
		health = 20;
		moveSpeed = 35;
		patrolSpeed = 0;
		rotationSpeed = 70;
		maxDistance = 100;
		attackRange = 75;
		patrol = false;
		
		weaponPrim = new Weapons(1,0,0.7f,0.9f,"CapsuleEnemy",0);
		weaponPrim.setAmmo (10000);
		primaryShot.gameObject.SetActive(true);
	}	
}
