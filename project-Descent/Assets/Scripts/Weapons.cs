using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson
Function: This class which is the base class for all weapon details. For the RC I got rid of the inheritance as no weapon
did anything special that required its own class.
It holds variables that determine how the weapon acts. Variables are public for testing. Note I'm mainly a Java person
so the code is set up more Javaie than maybe it should be.
It should be noted that it is possible to split up primary and secondary weapons once more. Because weapons do not contain
a lot of code or stats it seemed that keeping this together would be less messy.
Resources: NA
*/

[System.Serializable]
public class Weapons 
{
	/*Basic details about the weapon.*/
	public float energy;//How much energy a weapon needs to shot
	public float ammo;//how much ammo a you have of a type of weapon
	public float fireRate;//How fast you can fire
	public float nextFire;//when you can fire again
	public string name;
	private int weapNum;

	public Weapons(float e, float a, float f, float n, string name,int num){
		this.energy = e;
		this.ammo = a;
		this.fireRate = f;
		this.nextFire = n;
		this.name = name;
		this.weapNum = num;
	}


	public void setAmmo(float ammount)
	{
		ammo = ammount;
	}
	public float getAmmo()
	{
		return ammo;
	}


	/*This method is not used but is kept around for testing. Will be removed in future updates.
	It is now the player (PlayerStats) that control ammo 
	 */
	public bool loseAmmo(float ammount)
	{
		ammo = ammo - ammount;
		if (ammo >= 0) 
		{
			return true;
		} 
		else 
		{
			ammo += ammount;
			return false;
		}
	}

	 public int getWeaponNumber()
	{
		return weapNum;
	}
	
	 public string getName()
	{
		return name;
	}

}