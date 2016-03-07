using UnityEngine;
using System.Collections;

/*
Author: Chris Landon, Kory Bryson
Function: Decides the enemy's state and calls that state to perform its purpose. 
Contains possible pick up items that it may drop, player tracking and death functionality.
Resources: Unity tutorial/StackOverflow.
*/

public class EnemyLaserAI : MonoBehaviour{
	
	EnemyState state;
	public Enemy enemyHold;
	public Transform target;
	
	public GameObject explosion;
	public GameObject healthP;
	public GameObject energyP;
	public GameObject ammoP;
	public GameObject weaponP;
	public int dropChance = 75;

	public GameObject laser;
	int health;
	
	void Start () {
		health = 30;
	}
	
	void Update() { 
		if(PlayerSeen()){
			laser.SetActive(true);
		}
		else{
			laser.SetActive(false);
		}

	}
	private bool PlayerSeen() {
		GameObject other = GameObject.FindGameObjectWithTag ("Player") as GameObject;
		float dist = Vector3.Distance(other.transform.position, transform.position);

		if(dist < 70){
			return true;
		}

		return false;
	}

	public void ApplyDamage(int d) {

		health -= d;
		
		if (health <= 0) {
			if (Random.Range(0,125) < dropChance) {
				int type = Random.Range (0,100);
				if (type < 40) {
					Instantiate(healthP,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);
				}
				else if (type < 75) {
					Instantiate(energyP,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);
				}
				else if(type < 100){
					Instantiate(weaponP,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);
				}
				else {
					Instantiate(ammoP,GetComponent<Rigidbody>().position,GetComponent<Rigidbody>().rotation);
				}
			}
			
			Instantiate(explosion, transform.position, transform.rotation);
			Destroy(gameObject);
		}
	}
	
}