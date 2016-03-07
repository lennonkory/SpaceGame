using UnityEngine;
using System.Collections;
/*
Author:Mitchell Cook
Function: This class represents the ammo pickup. Upon 
trigger with the player it has its effect applied and is 
then destroyed by the player.
Resources: NA
 */

public class Pickup_Ammo : MonoBehaviour {

	public float effect = 10;

	public float getEffect()
	{
		return effect;
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Contains("Player"))
		{
			other.SendMessage ("PickupAmmo",gameObject,SendMessageOptions.DontRequireReceiver);
			
		}
	}
}
