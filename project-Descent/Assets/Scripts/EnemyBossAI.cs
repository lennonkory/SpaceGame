using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: Decides the boss's state and then calls that state to perform its purpose. 
			Contains player tacking and damage/death functionality. 
Resources: Unity tutorial/StackOverflow.
*/

public class EnemyBossAI : MonoBehaviour {
	
	EnemyState state;
	public EnemyBoss enemyHold;
	
	public Transform target;
	public Transform myTransform;
	public GameObject explosion;

	void Start () {
		//grabs enemy script attached to game object
		enemyHold = GetComponent<EnemyBoss>();
		enemyHold.Execute ();

		target = GameObject.FindWithTag ("Player").transform;
		myTransform = this.transform;
	}
	
	void Update() { 
		
		if (PlayerSeen()) {  
			
			RotateEnemy();
			
			if (ApproachPlayer()) {
				state = new EnemyState_Cautious();
			}
			
			if (AttackPlayer()) {
				state = new EnemyState_MultiAttack();
			}
			
		} else {
			state = new EnemyState_Idle ();
		}
		
		state.ExecuteBoss (this);
	}
	
	private bool PlayerSeen() {
		if (Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, myTransform.position) < enemyHold.maxDistance) {
			return true;
		} else {
			return false;
		}
	}
	
	private bool ApproachPlayer() {
		if (Vector3.Distance (GameObject.FindGameObjectWithTag ("Player").transform.position, myTransform.position) > enemyHold.attackRange - 70) {
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
			
			//death and explosion
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
	
}