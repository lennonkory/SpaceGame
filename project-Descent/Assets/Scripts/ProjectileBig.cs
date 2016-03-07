using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: Acts as a controller for the secondary weapon big. Changes rotation and applies damage to enemys. Again variables are
public for testing.
Resources: Based off space shooter to a small degree
*/

public class ProjectileBig : MonoBehaviour
{
	public float speed;
	public float Damage;
	public float lifetime;
	private float blowUpTime;
	public GameObject explosion;

	private float upDateTime;
	private float listTime = 0.15f;
	private ArrayList locations;

	void Start ()
	{
		GetComponent<AudioSource>().Play ();
		float num = 360 - transform.rotation.eulerAngles.x;
		GetComponent<Rigidbody>().rotation = Quaternion.Euler (90f - num, GetComponent<Rigidbody>().rotation.eulerAngles.y, 0);
		GetComponent<Rigidbody>().velocity = transform.forward * speed;

		blowUpTime = Time.time + lifetime;

		/*Used t0 keep track of locations of the projectile so that the explosion doesnt
		 blow up with in a wall.
		 */
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

		if (other.tag == "Enemy")
		{
			other.SendMessage("ApplyDamage",Damage,SendMessageOptions.DontRequireReceiver);
		}
	
		blowUp ();
		
	}

	void blowUp(){

		Vector3 blow = (Vector3)locations [locations.Count - 1];

		Instantiate (explosion,blow,transform.rotation);
		Destroy(gameObject);
	}

	void Update(){
		if(Time.time > blowUpTime){
			blowUp();
		}
		if(Time.time > upDateTime){
			locations.Add (transform.position);
			upDateTime = Time.time + listTime;
		}
	}
	
}