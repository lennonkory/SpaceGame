using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Abstract class for enemy classes holding stats, patrol and weapon set up.
Resources: StackOverflow.
*/

public abstract class Enemy : MonoBehaviour{
	
	public int health;
	public int moveSpeed;
	public int patrolSpeed;
	public int rotationSpeed;
	public int maxDistance;
	public int attackRange;
	public bool patrol;

	//used only by patrol units
	public Vector3 startingPoint;
	public Vector3 rallyPoint;
	public Vector3 currentPoint;
	public int distanceToNextPoint;
	public int nextPoint;
	public float rotateTime;
	
	public Weapons weaponPrim;
	public GameObject primaryShot;
	public Transform shotSpawn;
	
	public abstract void Execute ();
	
}
