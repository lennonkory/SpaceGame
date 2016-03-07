using UnityEngine;
using System.Collections;
/*
Author:Mitchell Cook
Function: This class represents the Invincibility pickup. Upon 
trigger with the player it has its effect applied and is 
then destroyed by the player. Effect in this class refers to 
the time the player is invincible.
Resources: NA
 */

public class Pickup_Invincibility : MonoBehaviour {
	
	public float effect = 15;
	
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
			other.SendMessage ("PickupInvincibility",gameObject,SendMessageOptions.DontRequireReceiver);
			
		}
	}
}
