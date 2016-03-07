using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the carry over of stats and weapons between levels. 
It is created in the main menu and is never destroyed unless the player 
returns to the main menu.
Resources: NA
*/

public class CarryOverStats : MonoBehaviour {
	
	public float health = 100.0f;
	public float energy = 100.0f;
	public float ammoM = 100.0f;
	public float ammoB = 100.0f;
	public float ammoH = 100.0f;
	public float ammoF = 100.0f;
	public float armor = 0.0f;

	public ArrayList weapPrim;
	public ArrayList weapSec;

	public void setCarryOverStats(float health,float energy,float ammoM,float ammoB,float ammoH,float ammoF,float armor,ArrayList prim, ArrayList sec)
	{
		this.health = health;
		this.energy = energy;
		this.ammoH = ammoH;
		this.ammoB = ammoB;
		this.ammoM = ammoM;
		this.ammoF = ammoF;
		this.armor = armor;
		this.weapPrim = prim;
		this.weapSec = sec;
	}
	public float getHealth ()
	{
		return health;
	}
	public float getEnergy ()
	{
		return energy;
	}
	public float getAmmoH ()
	{
		return ammoH;
	}
	public float getAmmoM ()
	{
		return ammoM;
	}
	public float getAmmoB ()
	{
		return ammoB;
	}
	public float getAmmoF ()
	{
		return ammoF;
	}
	public float getArmor()
	{
		return armor;
	}

	public void setPrimaryWeapons(ArrayList weapPrim){
		this.weapPrim = weapPrim;
	}
	public ArrayList getPrimaryWeapons(){
		return weapPrim;
	}

	public void setSecondaryWeapons(ArrayList weapSec){
		this.weapSec = weapSec;
	}
	public ArrayList getSecondaryWeapons(){
		return weapSec;
	}

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
