using UnityEngine;
using System.Collections;

/*
Author: Mitchell Cook
Function: This class handles activating the disruptive state when
a player makes contact with an object holding this script.
Resources: NA
*/

public class FireWall : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage("addState",new FireState(1,2,other.gameObject.GetComponent<PlayerStats>()));
		}
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			other.SendMessage("addState",new FireState(1,2,other.GetComponent<PlayerStats>()));
		}
		
	}
}
