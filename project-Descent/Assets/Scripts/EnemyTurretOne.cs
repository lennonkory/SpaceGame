using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Enemy standard class for static enemies, holding declaring/holding their stats, patrol and weapon set up.
Resources: StackOverflow.
*/

public class EnemyTurretOne : Enemy {

	public override void Execute () 
	{
		health = 30;
		moveSpeed = 0;
		patrolSpeed = 0;
		rotationSpeed = 40;
		maxDistance = 150;
		attackRange = 150;
		patrol = false;
		
		weaponPrim = new Weapons(1,0,0.5f,0.8f,"Capsule",0);
		weaponPrim.setAmmo (10000);
		primaryShot.gameObject.SetActive(true);
	}	
}
