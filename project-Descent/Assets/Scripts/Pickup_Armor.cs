using UnityEngine;
using System.Collections;
/*
Author:Mitchell Cook
Function: This class represents the armor pickup. Upon 
trigger with the player it has its effect applied and is 
then destroyed by the player.
Resources: NA
 */

public class Pickup_Armor : MonoBehaviour {
	
	public float effect = 25;
	
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
			other.SendMessage ("PickupArmor",gameObject,SendMessageOptions.DontRequireReceiver);
			
		}
	}
}
