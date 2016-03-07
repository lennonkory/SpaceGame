/*
Author: Gregory Campbell
Function: Gives a Wall health and allows it to take damage and be broken, wall object is destroyed when health reaches 0.
*/

using UnityEngine;
using System.Collections;

public class BreakableWall : MonoBehaviour {

	//Gives wall health to determine if broken
	public int health = 2;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (health <= 0) {
			Destroy(gameObject);
		}
	}

	
	void ApplyDamage(float damage)
	{
		//destroy the wall in here
	}

	//Wall takes damage from primary or secondary ammo
	void OnTriggerEnter (Collider other)
	{
		Debug.Log("HIT");
		if (other.tag == "Bolt") {

			health = 0;
		
		} else if (other.tag == "Cap") {

			health -= 1;
		
		}

		//Wall is destroyed once health = 0
		if (health <= 0) {
			Destroy(gameObject);
		}
	}
}
