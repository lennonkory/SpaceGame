using UnityEngine;
using System.Collections;
/*
Author:Kory Bryson
Function: Determines if the player flew into the ball
Resources: The ball model was taken from https://www.assetstore.unity3d.com/en/#!/content/446
*/

public class TheBall : MonoBehaviour {

	
	void OnTriggerEnter (Collider other)
	{
		if(other.tag == "Player"){
			Destroy(gameObject);
		}
	}
}
