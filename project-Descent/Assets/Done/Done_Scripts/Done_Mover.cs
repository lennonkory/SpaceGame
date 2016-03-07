using UnityEngine;
using System.Collections;

public class Done_Mover : MonoBehaviour
{
	public float speed;
	public float Damage;
	
	void Start ()
	{
		GetComponent<Rigidbody>().velocity = transform.forward * speed;
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (other.tag == "Enemy")
		{
			other.SendMessage("ApplyDamage",Damage,SendMessageOptions.DontRequireReceiver);
		}
		
		Destroy(gameObject);
		
	}
	public void THISISME(){
		Debug.Log("WHATS UP");
	}
}