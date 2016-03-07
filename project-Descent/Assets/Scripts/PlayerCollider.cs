using UnityEngine;
using System.Collections;
/*
Author:Mitchell Cook
Function: This class handles collisions and triggers on the player. 
It also holds any functions that other objects will call on trigger 
with the player.
Resources: NA
 */
public class PlayerCollider : MonoBehaviour {
	
	private float damage;
	private PlayerStats stats;
	private PlayerState2 state2;
	private UIDisplayHealth ui;

	public GameObject pickUpSound;
	public GameObject wallSound;

	void Awake()
	{
		state2 = GetComponent<PlayerState2> ();
		stats = GetComponent<PlayerStats> ();
		ui = GetComponentInChildren<Canvas> ().GetComponentInChildren<UIDisplayHealth> ();
	}
	
	bool OnCollisionEnter(Collision other)
	{
		
		//print (other.gameObject.name);
		if (other.gameObject.tag == "Wall") 
		{
			PlayWallSound();
			damage = Mathf.Min ((int)(Mathf.Sqrt(other.relativeVelocity.magnitude)*0.8f),5);
			//state.addState("stunned",Mathf.Sqrt(other.relativeVelocity.magnitude)*0.35f);
			state2.addState(new StunnedState(Mathf.Min (Mathf.Sqrt(other.relativeVelocity.magnitude)*0.275f,0.75f)));
			//state2.addState(new DisruptedState(5));
			//state2.addState(new FireState(2,5,stats));
			//state2.addState(new SlowState(40,4,gameObject));
			//state2.addState(new InvincibilityState(10));
			if (damage<2)
			{
				damage = 0;
			}
			if (stats.loseHealth(damage)==false)
			{
				Destroy(gameObject);
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	
		return true;
	}
	
	void ApplyDamage(float damage)
	{
		//state.addState ("disrupted",3.0f);
		if (stats.loseHealth((int)damage)==false)
		{
			Destroy(gameObject);
			Application.LoadLevel(Application.loadedLevel);
		}
	}

	public void DamageDirection(Rigidbody body)
	{
		ui.DamageDirection (body);
	}
	
	void PlayPickupSound()
	{
		Instantiate(pickUpSound, transform.position, transform.rotation);
	}
	void PlayWallSound()
	{
		Instantiate(wallSound, transform.position, transform.rotation);
	}

	void PickupHealth(GameObject pickup)
	{
		Pickup_Health A = pickup.GetComponent<Pickup_Health>();
		if (pickup.tag.Contains ("Health")) {
			if (stats.gainHealth(A.getEffect())==true)
			{
				PlayPickupSound();
				Destroy(pickup);
			}
		}
	}

	
	void PickupAmmo(GameObject pickup)
	{
		if (pickup.tag.Contains ("Ammo")) {
			Pickup_Ammo A = pickup.GetComponent<Pickup_Ammo>();
			if (stats.gainActiveAmmo(A.getEffect())==true)
			{
				PlayPickupSound();
				Destroy(pickup);
			}
		}
	}


	void PickupEnergy(GameObject pickup)
	{
		if (pickup.tag.Contains ("Energy")) {
			Pickup_Energy A = pickup.GetComponent<Pickup_Energy>();
			if (stats.gainEnergy(A.getEffect())==true)
			{
				PlayPickupSound();
				Destroy(pickup);
			}
		}
	}
	
	void PickupArmor(GameObject pickup)
	{
		Pickup_Armor A = pickup.GetComponent<Pickup_Armor>();
		if (pickup.tag.Contains ("Armor")) {
			if (stats.gainArmor(A.getEffect())==true)
			{
				PlayPickupSound();
				Destroy(pickup);
			}
		}
	}
	
	void PickupInvincibility(GameObject pickup)
	{
		Pickup_Invincibility A = pickup.GetComponent<Pickup_Invincibility>();
		if (pickup.tag.Contains ("Invincibility")) {
			state2.addState(new InvincibilityState(A.getEffect()));
			PlayPickupSound();
			Destroy(pickup);
		}
	}


	void ApplyState(string state)
	{
		return;
	}
	
	
	bool OnTriggerEnter (Collider other)
	{
		return true;
	}
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
