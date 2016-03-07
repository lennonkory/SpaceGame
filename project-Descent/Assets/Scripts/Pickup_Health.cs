using UnityEngine;
using System.Collections;
/*
Author:Mitchell Cook
Function: This class represents the health pickup. Upon 
trigger with the player it has its effect applied and is 
then destroyed by the player.
Resources: NA
 */

public class Pickup_Health : MonoBehaviour {

	public float effect =10;

	// Use this for initialization
	void Start () {
	
	}

	public float getEffect()
	{
		return effect;
	}

	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Contains("Player"))
		{
			other.SendMessage ("PickupHealth",gameObject,SendMessageOptions.DontRequireReceiver);
	
		}
	}
}
