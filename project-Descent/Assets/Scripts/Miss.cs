using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: Controls the homing missile. I only modifed this code to make it work with the game. I take no real credit for it.
Resources:http://xenosmashgames.com/homing-missile-unity-3d/
*/

public class Miss : MonoBehaviour {

	Transform target;
	public Rigidbody hoMis;
	public GameObject misss;
	public GameObject explosion;
	private float blowUpTime;
	public string targetTag;

	private float upDateTime;
	private float listTime = 0.15f;
	private ArrayList locations;

	void Start () {

		hoMis = transform.GetComponent<Rigidbody>();

		float dis = Mathf.Infinity;

		foreach(GameObject i in GameObject.FindGameObjectsWithTag (targetTag)){
			float diff = (i.transform.position - transform.position).sqrMagnitude;

			if(diff < dis){
				dis = diff;
				target = i.transform;
			}

		}

		GetComponent<AudioSource>().Play ();

		if(dis == Mathf.Infinity){
			Destroy (gameObject);
		}

		blowUpTime = Time.time + 5;

		upDateTime = Time.time + listTime;
		locations = new ArrayList ();
		locations.Add (transform.position);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
		if(target == null || hoMis == null){
			return;
		}

		hoMis.velocity = transform.forward * 30;

		Quaternion targetRotation = Quaternion.LookRotation (target.position - transform.position);

		hoMis.MoveRotation(Quaternion.RotateTowards (transform.rotation,targetRotation,20));

	}

	void OnTriggerEnter (Collider other)
	{
		
		if(other.tag == "Cap" || other.tag == "Armor" || other.tag == "Health" || other.tag == "Energy"|| other.tag == "Ammo"){
			return;
		}

		other.SendMessage("ApplyDamage",20,SendMessageOptions.DontRequireReceiver);
		
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
