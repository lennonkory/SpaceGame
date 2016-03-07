using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: Controls Weapon pick ups. Randomly drops a new weapon for the player.
Resources:NA
*/

public class WeaponPick : MonoBehaviour {

	public string weapon;

	string [] weaponListPrim = new string[4];
	string [] weaponListSec = new string[4];

	void OnTriggerEnter(Collider other)
	{
		if (other.tag.Contains("Player"))
		{
			int prim = Random.Range(0,2);
			if(prim == 0){
				other.SendMessage ("addToPrimaryPlayer",weaponListPrim[Random.Range(0,weaponListPrim.Length)],SendMessageOptions.DontRequireReceiver);
			}
			else{
				other.SendMessage ("addToSecondaryPlayer",weaponListSec[Random.Range(0,weaponListSec.Length)],SendMessageOptions.DontRequireReceiver);
			}
			Destroy(gameObject);
		}
	}
	

	void Start(){
		weaponListPrim[0] = "Fire";
		weaponListPrim[1] = "CapFire";
		weaponListPrim[2] = "LaserK";
		weaponListPrim[3] = "Small";

		weaponListSec [0] = "Bomb";
		weaponListSec [1] = "Homing";
		weaponListSec [2] = "Big";
		weaponListSec [3] = "FlyingBomb";

		weapon = "Fire";
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
	}

}
