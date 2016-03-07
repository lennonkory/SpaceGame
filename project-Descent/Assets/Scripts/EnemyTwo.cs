using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Enemy class for large size enemies, holding declaring/holding their stats, patrol and weapon set up.
Resources: StackOverflow.
*/

public class EnemyTwo : Enemy {
	
	public override void Execute () 
	{
		health = 50;
		moveSpeed = 10;
		patrolSpeed = 0;
		rotationSpeed = 30;
		maxDistance = 120;
		attackRange = 100;
		patrol = false;
		
		weaponPrim = new Weapons(1,0,1.2f,1.4f,"CapsuleEnemyFire",0);
		weaponPrim.setAmmo (10000);
		primaryShot.gameObject.SetActive(true);
	}
}
