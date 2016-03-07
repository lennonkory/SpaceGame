using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: Controls the final bosses main weapon.
Resources:NA
*/

public class FireBall : MonoBehaviour {

	public GameObject explosion;
	private float blowUp = 2;
	public float Damage;
	public float radius = 5.0F;
	public float power = 10.0F;

	void Start () {
		GetComponent<Rigidbody>().velocity = transform.forward * 19;
		blowUp = Time.time + 2;
	}


	void OnTriggerEnter (Collider other)
	{
		BlowUp(true);

	}

	bool OnCollisionEnter(Collision other)
	{
		BlowUp (true);
		return true;
	}

	void BlowUp(bool touch)
	{

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
		
		/*Damage is delt for each object the bomb can hit*/
		foreach (Collider hit in colliders) 
		{
			float realDam = 0;
			
			/*bomb does not damage itself or walls*/
			if( hit.tag =="Enemy" || hit.tag =="enemy")
			{

				if (hit && hit.GetComponent<Rigidbody>())
				{
					/*Throws the object in a direction. Note this maybe to powerful
					I ramped it up to push the player around. If you add a cube to the game
					and set a bomb off the cube goes flying like mad. Its pretty awesome.
					 */
					hit.GetComponent<Rigidbody>().AddExplosionForce(power, explosionPos, radius, 3.0F);
					
					/*A raycast is used to find the distance from the bomb to the object it hit
					damage is delt based on this distance
					 */
					RaycastHit ray;
					int theDamage = (int)Damage;
					if (touch)
					{
						hit.SendMessage("ApplyDamage",theDamage,SendMessageOptions.DontRequireReceiver);
					}
					
					if(Physics.Raycast(transform.position,-Vector3.up,out ray))
					{
						/*If distance is less than one its 1 (avoid divide by zero)*/
						float temp = ray.distance;
						if (temp < 1)
						{
							temp = 1;
						}
						if(temp != 0)
						{
							/*realDam is the actual damage that is delt. As of right now
							its just the bombs regular damage/the distance (temp)
							This may change if it doesn't feel right
							 */
							realDam = Damage/temp;
						}
						
						theDamage = (int) Mathf.Round (realDam);
						
						hit.SendMessage("ApplyDamage",theDamage,SendMessageOptions.DontRequireReceiver);
					}
					
				}
			}
		}

		Instantiate (explosion,transform.position,transform.rotation);
		Destroy (transform.root.gameObject);
	}
	//The FireBall has a timer and will blowup in a set amount of time
	void Update(){
		if(Time.time > blowUp)
		{
			BlowUp(false);
		}
	}

}
