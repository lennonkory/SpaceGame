using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: Contains the GameObjects (projectiles) and switches between them
Resources:NA
*/

[System.Serializable]
public class WeaponController {

	public ArrayList weapPrim = new ArrayList();
	public ArrayList weapSec = new ArrayList();

	public void loadWeapons(){

		weapPrim.Clear();
		weapSec.Clear ();

		weapPrim.Add (Resources.Load("Capsule") as GameObject);

		weapSec.Add (Resources.Load("Big") as GameObject);
	
	}

	public void loadAllWeapons(){

		weapPrim.Clear();
		weapSec.Clear ();

		weapPrim.Add (Resources.Load("Capsule") as GameObject);
		weapPrim.Add (Resources.Load("CapFire") as GameObject);
		weapPrim.Add (Resources.Load("FIRE") as GameObject);
		weapPrim.Add (Resources.Load("LaserK") as GameObject);
		weapPrim.Add (Resources.Load("Small") as GameObject);

		weapSec.Add (Resources.Load("Big") as GameObject);
		weapSec.Add (Resources.Load("Bomb") as GameObject);
		weapSec.Add (Resources.Load("Homing") as GameObject);
		weapSec.Add (Resources.Load("FlyingBomb") as GameObject);
	
	}
	
	public void setPrimList(ArrayList weapPrim){
		if(weapPrim == null || weapPrim.Count == 0){
			loadWeapons();
			return;
		}
		this.weapPrim = weapPrim;
	}

	public void setSecList(ArrayList weapSec){
		if(weapSec == null || weapSec.Count == 0){
			loadWeapons();
			return;
		}
		this.weapSec = weapSec;
	}

	public ArrayList getPrimList(){
		return this.weapPrim;
	}
	
	public ArrayList getSecList(){
		return this.weapSec;
	}

	public bool addToPrimary(GameObject go){

		UIDisplayHealth UID = GameObject.FindObjectOfType(typeof(UIDisplayHealth)) as UIDisplayHealth;

		foreach(GameObject g in weapPrim){
			if(g.name.Equals(go.name)){
				UID.KoryMessage("Already have: " + go.name + "\nAdding Energy");
				return false;
			}
		}
		UID.KoryMessage("Added Primary Weapon: " + go.name);

		weapPrim.Add (go);
		return true;
	}

	public bool addToSecondary(GameObject go){

		UIDisplayHealth UID = GameObject.FindObjectOfType(typeof(UIDisplayHealth)) as UIDisplayHealth;

		foreach(GameObject g in weapSec){
			if(g.name.Equals(go.name)){
				UID.KoryMessage("Already have: " + go.name+ "\nAdding to Ammo");
			
				return false;
			}
		}
		UID.KoryMessage("Added Secondary Weapon: " + go.name);

		weapSec.Add (go);
		return true;
	}

	public int getPrimSize(){

		return weapPrim.Count;

	}

	public int getSecSize(){
		return weapSec.Count;
	}

	public Weapons getPrimWeapon(int num){

		GameObject go = weapPrim [num] as GameObject;

		if(go.name.Equals("CapFire") || go.name.Equals("Capsule")){
			return new Weapons(1f,0f,0.3f,0.5f,go.name,0);
		}
		if(go.name.Equals("Small") ){
			return new Weapons(1f,0f,0.2f,0.4f,go.name,0);
		}
		if(go.name.Equals("LaserK")){
			return new Weapons(0.10f,0f,0.25f,0.2f,"Laser",2);
		}
		if(go.name.Equals("Fire")){
			return new Weapons(4f,0f,0.6f,0.8f,"Fire",1);
		}
		if(go.name.Equals("BoltTwo")){
			return new Weapons(4f,0f,0.6f,0.8f,"BoltTwo",1);
		}
		return null;
	}

	public Weapons getSecWeapon(int num){

		GameObject go = weapSec [num] as GameObject;


		if(go.name.Equals("Big")){
			return new Weapons(0f,10f,1f,0.5f,"Big",0);
		}
		if(go.name.Equals("Bomb")){
			return new Weapons(0f,10f,2f,0.9f,"Bomb",1);
		}
		if(go.name.Equals("FlyingBomb")){
			return new Weapons(0f,10f,2f,0.9f,"FlyingBomb",3);
		}
		if(go.name.Equals("Homing")){
			return new Weapons(0f,10f,1.25f,0.9f,"Homing",2);
		}
		return null;
	}

	public GameObject getPrimary(int num){
		return (GameObject)weapPrim[num];
	}

	public GameObject getSecondary(int num){
		return (GameObject)weapSec[num];
	}
}