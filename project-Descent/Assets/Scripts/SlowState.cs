using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the slow state of the player and enemy. 
While this state is applied it will slow  movement speed and max 
speed of the ship. if the player is slowed while already slowed it will 
add the slow, up to 80% slow, and increase the time to the max of the 2 slows
Resources: NA
*/


public class SlowState : State {
	public float ammount;
	public float time;
	GameObject ship;
	float speed;
	float maxSpeed;
	int type;
	public SlowState(float ammount, float time,GameObject ship){
		//stats = GetComponent<PlayerStats>();
		this.ammount = ammount;
		this.time = Time.time + time;
		this.ship = ship;

		if (ship.tag == "Player") {
						type = 0;
						speed = ship.GetComponent<CharacterMovement2> ().speed;
						maxSpeed = ship.GetComponent<CharacterMovement2> ().maxXSpeed;
		} 
		else if (ship.tag == "Enemy") {
			ship.GetComponent<Enemy>().moveSpeed = (int)speed;
			speed = ship.GetComponent<Enemy>().moveSpeed;
			type = 1;
		}
	}

	public string getState()
	{ 
		return "Slow";
	}
	//true if applied
	//false if not

	public void updateState(State state)
	{
		this.ammount = Mathf.Min (80, ((SlowState)state).ammount + this.ammount);
		this.time = Mathf.Max (((SlowState)state).time, this.time);
	}

	public bool apply()
	{
		if (Time.time > this.time) {

			if (type ==0)
			{
				ship.GetComponent<CharacterMovement2>().speed=speed;
				ship.GetComponent<CharacterMovement2>().maxXSpeed=maxSpeed;
				ship.GetComponent<CharacterMovement2>().maxYSpeed=maxSpeed;
				ship.GetComponent<CharacterMovement2>().maxZSpeed=maxSpeed;
			}
			else if (type ==1)
			{
				ship.GetComponent<Enemy>().moveSpeed = (int)speed;
			}
			return false;
		}
		if (type == 0) {
						ship.GetComponent<CharacterMovement2> ().speed =speed * Mathf.Abs (1 - (ammount / 100));
						ship.GetComponent<CharacterMovement2> ().maxXSpeed = maxSpeed * Mathf.Abs (1 - (ammount / 100));
						ship.GetComponent<CharacterMovement2> ().maxYSpeed = maxSpeed * Mathf.Abs (1 - (ammount / 100));
						ship.GetComponent<CharacterMovement2> ().maxZSpeed = maxSpeed * Mathf.Abs (1 - (ammount / 100));
				}
		return true;
	}
	public void removeState()
	{
		ship.GetComponent<CharacterMovement2>().speed=speed;
		ship.GetComponent<CharacterMovement2>().maxXSpeed=maxSpeed;
		ship.GetComponent<CharacterMovement2>().maxYSpeed=maxSpeed;
		ship.GetComponent<CharacterMovement2>().maxZSpeed=maxSpeed;

	}
}
