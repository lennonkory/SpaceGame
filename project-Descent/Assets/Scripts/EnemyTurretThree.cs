using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Enemy laser class for static enemies, holding declaring/holding their stats, patrol and weapon set up.
Resources: StackOverflow.
*/

public class EnemyTurretThree : Enemy {
	
	public override void Execute () 
	{
		health = 20;
		moveSpeed = 0;
		patrolSpeed = 0;
		rotationSpeed = 40;
		maxDistance = 150;
		attackRange = 150;
		patrol = false;
		
		weaponPrim = new Weapons(1,0,0.1f,0.3f,"Laser",0);
		weaponPrim.setAmmo (10000);
		primaryShot.gameObject.SetActive(true);
	}	
}
