using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: Destroys a gameObject in a set amount of time
Resources:NA
*/

public class DestroyInTime : MonoBehaviour {

	public float lifetime;

	// Use this for initialization
	void Start () {
		Destroy (gameObject,lifetime);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
