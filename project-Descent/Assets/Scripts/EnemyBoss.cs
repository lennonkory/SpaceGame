using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Enemy class for Boss, holding declaring/holding their stats, patrol and weapon set up.
Resources: StackOverflow.
*/

public class EnemyBoss : Enemy {

	public Weapons weaponPrim2;
	public GameObject primaryShot2;
	public Transform shotSpawn2;

	public Weapons weaponPrim3;
	public GameObject primaryShot3;
	public Transform shotSpawn3;

	public Weapons weaponPrim4;
	public GameObject primaryShot4;
	public Transform shotSpawn4;

	public int bombRange;

	public override void Execute () 
	{
		health = 400;
		moveSpeed = 30;
		patrolSpeed = 0;
		rotationSpeed = 50;
		maxDistance = 160;
		attackRange = 130;
		bombRange = 60;
		patrol = false;
		
		weaponPrim = new Weapons(1,0,1.5f,1.7f,"fireBall",0);
		weaponPrim.setAmmo (10000);
		primaryShot.gameObject.SetActive(true);

		weaponPrim2 = new Weapons(1,0,0.7f,0.9f,"CapsuleEnemyFire",0);
		weaponPrim2.setAmmo (10000);
		primaryShot2.gameObject.SetActive(true);

		weaponPrim3 = new Weapons(1,0,0.7f,0.9f,"CapsuleEnemyFire",0);
		weaponPrim3.setAmmo (10000);
		primaryShot3.gameObject.SetActive(true);

		weaponPrim4 = new Weapons(1,0,5.0f,7.0f,"HomingEnemy",0);
		weaponPrim4.setAmmo (10000);
		primaryShot4.gameObject.SetActive(true);
	}	
}
