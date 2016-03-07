using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: Controls how individual projectiles work (In this case the projectile Fire). 
Note that settings for the projectile are public so they can be changed by the Inspector. This is for testing and will be changed
for later releases. For the Alpha we needed at least 2 primary weapons (there are 3). These weapons vary in size, damage, speed and rate
at which they can be fired.
Resources: This scripted started out as the one from the Space Shooter tutorial but has been reworked a lot. The textures are from space shooter.
the audio files are taken from space shooter. Fire effect is taken from https://www.assetstore.unity3d.com/en/#!/content/21587
 */

public class FIRE : MonoBehaviour
{
	public float speed;
	public float Damage;
	public float lifetime;
	public AudioSource audio1;

	public GameObject fire;

	private float upDateTime;
	private float listTime = 0.15f;
	private ArrayList locations;

	void Start ()
	{
		
		audio1.Play ();
		GetComponent<Rigidbody>().velocity = transform.parent.forward * speed;
		//Destroy (gameObject, lifetime);
		Destroy (transform.root.gameObject,lifetime);

		upDateTime = Time.time + listTime;
		locations = new ArrayList ();
		locations.Add (transform.position);

	}
	
	
	void OnTriggerEnter (Collider other)
	{
		
		if (other.tag == "Bolt" || other.tag == "Cap" || other.tag == "Armor" || other.tag == "Health" || other.tag == "Energy"|| other.tag == "Ammo") 
		{
			return;
		}
		
		if (other.tag == "Player")
		{
			/*sends damge to enemy*/
			other.SendMessage("ApplyDamage",Damage,SendMessageOptions.DontRequireReceiver);
			other.SendMessage("DamageDirection",GetComponent<Rigidbody>(),SendMessageOptions.DontRequireReceiver);
		}
		
		if (other.tag == "Enemy")
		{
			/*sends damge to enemy*/
			other.SendMessage("ApplyDamage",Damage,SendMessageOptions.DontRequireReceiver);
			
		}
		Vector3 blow = (Vector3)locations [locations.Count - 1];
		Instantiate (fire,blow,transform.rotation);
		Destroy(transform.root.gameObject);
		
	}

	void Update(){

		if(Time.time > upDateTime){
			locations.Add (transform.position);
			upDateTime = Time.time + listTime;
		}
	}
	
	
}