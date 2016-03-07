/*
	This script is placed in public domain. The author takes no responsibility for any possible harm.
	Contributed by Jonathan Czeck
*/
using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: Determines if the Player is in range and shoots a laser at him/her.
Resources: I got this asset from Professor Nikitenko. I only modified it a little (ie getTarget()).
*/

public class LightEnemy : MonoBehaviour
{
	public Transform target;
	public Transform noEnemy;
	public Transform gunBody;
	public int zigs = 100;
	public float speed = 1f;
	public float scale = 1f;
	public Light startLight;
	public Light endLight;

	private float applyDamage;

	Perlin noise;
	float oneOverZigs;
	
	private Particle[] particles;
	
	void Start()
	{
		oneOverZigs = 1f / (float)zigs;
		GetComponent<ParticleEmitter>().emit = false;
		
		GetComponent<ParticleEmitter>().Emit(zigs);
		particles = GetComponent<ParticleEmitter>().particles;
		applyDamage = Time.time;
		getTarget ();
		
	}

	/*Is the player in range. Sets the Target to the players location*/
	public bool getTarget(){

		GameObject other = GameObject.FindGameObjectWithTag ("Player") as GameObject;
		float dist = Vector3.Distance(other.transform.position, transform.position);
		
		if(dist < 70){
			target = other.transform;
			return true;
		}
		
		return false;

	}
	
	void Update ()
	{

		if(!getTarget ()){
			return;
		}


		if(Time.time > applyDamage){
			target.SendMessage("ApplyDamage", 1, SendMessageOptions.DontRequireReceiver);
			applyDamage = Time.time + 0.25f;
		}

		gunBody.LookAt(target);
		if (noise == null)
			noise = new Perlin();
		
		float timex = Time.time * speed * 0.1365143f;
		float timey = Time.time * speed * 1.21688f;
		float timez = Time.time * speed * 2.5564f;
		
		for (int i=0; i < particles.Length; i++)
		{
			Vector3 position = Vector3.Lerp(transform.parent.position, target.position, oneOverZigs * (float)i);
			Vector3 offset = new Vector3(noise.Noise(timex + position.x, timex + position.y, timex + position.z),
			                             noise.Noise(timey + position.x, timey + position.y, timey + position.z),
			                             noise.Noise(timez + position.x, timez + position.y, timez + position.z));
			position += (offset * scale * ((float)i * oneOverZigs));
			
			particles[i].position = position;
			particles[i].color = Color.white;
			particles[i].energy = 1f;
		}
		
		GetComponent<ParticleEmitter>().particles = particles;
		
		if (GetComponent<ParticleEmitter>().particleCount >= 2)
		{
			if (startLight)
				startLight.transform.position = particles[0].position;
			if (endLight)
				endLight.transform.position = particles[particles.Length - 1].position;
		}
		
		
		
	}
	
}