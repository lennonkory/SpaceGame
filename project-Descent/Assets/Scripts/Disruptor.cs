using UnityEngine;
using System.Collections;

/*
Author: Gregory Campbell
Function: This class handles activating the disruptive state when
a player makes contact with an object holding this script.
Resources: FireWall Script
*/

public class Disruptor : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnCollisionEnter(Collision other)
	{
		if (other.gameObject.tag == "Player") {
			other.gameObject.SendMessage("addState",new DisruptedState(3));
		}
		
	}
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") {
			other.SendMessage("addState",new DisruptedState(3));
			other.SendMessage("loseEnergy", 5);
		}
		
	}
}
