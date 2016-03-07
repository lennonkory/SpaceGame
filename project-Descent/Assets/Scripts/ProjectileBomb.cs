using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: Controls explosive weapons. Public variables are for testing. Controls Instantiation and expolsions. Nothing is done
yet for any animations. As of right now the bomb explodes after a period of time. That will be changed to also exploding
when it hits an enemy. Also the bomb just falls to the floor and is rather useless as of right not. In the future it will float
in the air so an enemy (or unlucky player) can run into it.
Resources: Basic layout comes from space shooter. Idea for BlowUp() comes from http://docs.unity3d.com/ScriptReference/Rigidbody.AddExplosionForce.html
*/

public class ProjectileBomb : MonoBehaviour
{
	public float speed;
	public float Damage;
	public float lifetime;
	private float blowUp;
	public float radius = 5.0F;
	public float power = 10.0F;

	public AudioSource audio1;

	public GameObject explosion;

	void Start ()
	{
		audio1.Play ();
		blowUp = Time.time +3f; //When the bomb will blow up
		GetComponent<Rigidbody>().velocity = -transform.up * speed;
		//Destroy (transform.root.gameObject,lifetime + 1);
	}
	
	bool OnCollisionEnter(Collision other)
	{
		//This function will call BlowUp() in future release.
		BlowUp (true);
		return true;
	}

	/*This method controls how much damage is delt when the bomb goes off*/
	void BlowUp(bool touch)
	{

		Vector3 explosionPos = transform.position;
		Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);

		/*Damage is delt for each object the bomb can hit*/
		foreach (Collider hit in colliders) 
		{

			float realDam = 0;

			/*bomb does not damage itself or walls*/
			if(hit.tag =="Player" || hit.tag =="Enemy")
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

		Instantiate(explosion, transform.position, transform.rotation);
		Destroy (transform.root.gameObject);
	}

	void Update()
	{

		if(Time.time > blowUp)
		{
			BlowUp(false);
		}

	}
}