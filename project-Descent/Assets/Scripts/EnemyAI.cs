using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Decides the enemy's state and then calls that state to perform its purpose. 
			Contains possible pick up items that enemy may drop, player tracking and damage/death functionality. 
Resources: Unity tutorial/StackOverflow.
*/

public class EnemyAI : MonoBehaviour {
	
	EnemyState state;
	public Enemy enemyHold;
	
	public Transform target;
	public Transform myTransform;
	public GameObject explosion;

	//pick ups
	public GameObject healthP;
	public GameObject energyP;
	public GameObject ammoP;
	public GameObject weaponP;
	public int dropChance = 50;

	void Start () {
		//grabs enemy script attached to game object
		enemyHold = GetComponent<Enemy>();
		enemyHold.Execute ();

		target = GameObject.FindWithTag ("Player").transform;
		myTransform = this.transform;

		//set up patrol points
		if (enemyHold.patrol == true) {
			enemyHold.startingPoint = new Vector3 (myTransform.position.x, myTransform.position.y, myTransform.position.z);
			enemyHold.rallyPoint = new Vector3 (myTransform.position.x, myTransform.position.y, myTransform.forward.z + enemyHold.distanceToNextPoint);
			enemyHold.currentPoint = enemyHold.rallyPoint;
			myTransform.LookAt (enemyHold.currentPoint);
		}
	}
	
	void Update() { 
		
		if (PlayerSeen()) {  
		
			RotateEnemy();
			
			if (ApproachPlayer()) {
				state = new EnemyState_Cautious();
			}
			
			if (AttackPlayer()) {
				state = new EnemyState_Attack();
			}
			
		} else {
			
			if(enemyHold.patrol == true) {		
				state = new EnemyState_Patrol ();
			}
			else {
				state = new EnemyState_Idle ();
			}
		}
		
		state.Execute (this);
	}
	
	private bool PlayerSeen() {
		if (Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, myTransform.position) < enemyHold.maxDistance) {
			return true;
		} else {
			return false;
		}
	}
	
	private bool ApproachPlayer() {
		if (Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, myTransform.position) > enemyHold.attackRange - 30) {
			return true;
		} else {
			return false;
		}
	}
	
	private bool AttackPlayer() {
		if (Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, myTransform.position) < enemyHold.attackRange) {
			return true;
		} else {
			return false;
		}
	}
	
	public void RotateEnemy() {
		//rotates towards target whenever in sight
		Transform rotateTarget = GameObject.FindGameObjectWithTag ("Player").transform;
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (rotateTarget.position - myTransform.position), enemyHold.rotationSpeed * Time.deltaTime);
	}
	
	public void ApplyDamage(int d) {
		//apply damage sent from projectile
		enemyHold.health -= d;

		//if enemy still has health
		if (enemyHold.health <= 0) {
			//if enemy drops an item
			if (Random.Range(0,100) < dropChance)
			{
				//what item to drop
				int type = Random.Range (0,100);
				if (type < 40) {
					Instantiate(healthP,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);
				}
				else if (type < 75) {
					Instantiate(energyP,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);
				}
				else if(type < 85) {
					Instantiate(weaponP,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);
				}
				else {
					Instantiate(ammoP,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);
				}
			}

			//death and explosion
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
	
}