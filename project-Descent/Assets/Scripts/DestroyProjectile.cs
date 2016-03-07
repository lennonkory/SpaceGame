using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: Destroys a projectile in a set amount of time.
Resources:NA
*/

public class DestroyProjectile : MonoBehaviour {
	public float lifetime;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, lifetime);
	}

	public void Die(){

	}

}
