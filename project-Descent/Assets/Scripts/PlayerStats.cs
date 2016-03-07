using UnityEngine;
using System.Collections;
/*
Author:Mitchell Cook
Function: This class holds the stats of the player as well as 
functions to be called by other classes to modify the stats. 
The stats the player has are: health energy and ammo, with ammo 
being split into different kinds.
Upon the start of each new scene a new player is created. Its 
stats are read from the CarryOver object that is carried over between levels
Resources: NA
 */
public class PlayerStats : MonoBehaviour {
	public float health=100.0f;
	public float energy=200.0f;
	public float MissleAmmo=100.0f;
	public float FlyingAmmo=100.0f;
	public float BombAmmo=100.0f;
	public float HomingAmmo = 100.0f;
	public float armor = 10.0f;

	public int activeAmmo = 0;

	public float maxHealth=200.0f;
	public float maxEnergy=200.0f;
	public float maxMissleAmmo=200.0f;
	public float maxBombAmmo=200.0f;
	public float maxHomingAmmo=200.0f;
	public float maxFlyingAmmo=200.0f;
	public float maxArmor = 100.0f;

	public ArrayList weapPrim;
	public ArrayList weapSec;

	CarryOverStats carry;

	public bool invincibility = false;
	public bool godMode = false;
	// Use this for initialization
	public void Start () {

		try{
			carry = GameObject.Find ("CarryOver").GetComponent<CarryOverStats> ();
			
		}
		catch
		{
			health = 100f;
			energy = 150f;
			MissleAmmo = 10f;
			BombAmmo = 10f;
			HomingAmmo = 10f;
			FlyingAmmo = 10f;
			return;
		}
		health = carry.getHealth();
		armor = carry.getArmor ();
		energy = carry.getEnergy ();
		MissleAmmo = carry.getAmmoM ();
		BombAmmo = carry.getAmmoB();
		HomingAmmo = carry.getAmmoH();
		FlyingAmmo = carry.getAmmoF ();
		weapPrim = carry.getPrimaryWeapons ();
		weapSec = carry.getSecondaryWeapons ();
	}

	public ArrayList getPrim(){
		weapPrim = GameObject.Find ("Player").GetComponent<PlayerController> ().weaponController.getPrimList();
		/*print ("**************");
		print("PRIM LIST:");
		foreach(GameObject o in weapPrim){
			print(o.name);
		}
		print ("**************");*/
		return weapPrim;
	}

	public ArrayList getSec(){
		weapSec = GameObject.Find ("Player").GetComponent<PlayerController> ().weaponController.getSecList();
		/*print ("**************");
		print("SECOND LIST:");
		foreach(GameObject o in weapSec){
			print(o.name);
		}
		print ("**************");*/
		return weapSec;
	}
	public ArrayList usePrimList(){
		return weapPrim;
	}
	public ArrayList useSecList(){
		return weapSec;
	}
	public float getHealth()
	{
		return health;
	}

	public float getEnergy()
	{
		return energy;
	}

	public float getAmmo()
	{
		if (activeAmmo == 0) {
			return MissleAmmo;
		} else if (activeAmmo == 1) {
			return BombAmmo;
		}
		else if (activeAmmo == 2) {
			return HomingAmmo;
		}
		else if (activeAmmo == 3) {
			return FlyingAmmo;
		}
		return 0;
	}

	public bool loseAmmo(float ammount)
	{
		if (godMode) {
			return true;
				}
		if (activeAmmo == 0) {
			return loseMissleAmmo (ammount);
		} else if (activeAmmo == 1) {
			return loseBombAmmo(ammount);
		}else if (activeAmmo == 2) {
			return loseHomingAmmo(ammount);
		}else if (activeAmmo == 3) {
			return loseFlyingAmmo(ammount);
		}
		return false;
	}

	public float getMissleAmmo()
	{
		return MissleAmmo;
	}

	public float getBombAmmo()
	{
		return BombAmmo;
	}

	public float getHomingAmmo()
	{
		return HomingAmmo;
	}
	public float getFlyingAmmo()
	{
		return FlyingAmmo;
	}
	
	public void setMissleAmmo(float ammount){
		MissleAmmo = ammount;
	}
	public void setBombAmmo(float ammount){
		BombAmmo = ammount;
	}
	public void setHomingAmmo(float ammount){
		HomingAmmo = ammount;
	}
	public void setFlyingAmmo(float ammount){
		FlyingAmmo = ammount;
	}

	//returns true if health is greater than 0
	//returns false if health becomes less than 0, no health is lost
	public bool loseHealth(float ammount)
	{
		if (invincibility || godMode) {
			return true;
				}
		float ammount2 = loseArmor (ammount);
		health = health - ammount2;
		if (health > 0) 
		{
			return true;
		} 
		else 
		{
			health=health+ammount2;
			return false;
		}
	}

	//returns true if health is gained
	//returns false if health is already at max, no health is gained
	public bool gainHealth(float ammount)
	{
		if (health == maxHealth) 
		{
			return false;
		}
		else
		{
			health = Mathf.Min (maxHealth,health+ammount);
			return true;
		}
	}

	
	public bool loseEnergy(float ammount)
	{
		if (godMode) {
			return true;
				}
		energy = energy - ammount;
		if (energy>= 0) 
		{
			return true;
		} 
		else 
		{
			energy=energy+ammount;
			return false;
		}
	}
	
	public bool gainEnergy(float ammount)
	{
		if (energy == maxEnergy) 
		{
			return false;
		}
		else
		{
			energy = Mathf.Min (maxEnergy,energy+ammount);
			return true;
		}
	}

	public bool gainAmmo(float ammount)
	{
		if (MissleAmmo == maxMissleAmmo && BombAmmo == maxBombAmmo) {
						return false;
				}
		else 
		{
			if (MissleAmmo != maxMissleAmmo)
			{
				MissleAmmo = Mathf.Min (maxMissleAmmo,MissleAmmo+ammount);
			}
			if (BombAmmo != maxBombAmmo)
			{
				BombAmmo = Mathf.Min (maxBombAmmo,BombAmmo+ammount);
			}
			if (HomingAmmo != maxHomingAmmo)
			{
				HomingAmmo = Mathf.Min (maxHomingAmmo,HomingAmmo+ammount);
			}
			if (FlyingAmmo != maxFlyingAmmo)
			{
				FlyingAmmo = Mathf.Min (maxFlyingAmmo,FlyingAmmo+ammount);
			}
			return true;
		}
	}

	public bool gainActiveAmmo(float ammount)
	{
		if (activeAmmo == 0) {
			return gainMissleAmmo (ammount);
		} else if (activeAmmo == 1) {
			return gainBombAmmo(ammount);
		}
		else if (activeAmmo == 2) {
			return gainHomingAmmo(ammount);
		}
		else if (activeAmmo == 3) {
			return gainFlyingAmmo(ammount);
		}
		return false;
	}
	
	public bool loseMissleAmmo(float ammount)
	{
		MissleAmmo = MissleAmmo - ammount;
		if (MissleAmmo >= 0) 
		{
			return true;
		} 
		else 
		{
			MissleAmmo=MissleAmmo+ammount;
			return false;
		}
	}
	
	public bool gainMissleAmmo(float ammount)
	{

		if (MissleAmmo == maxMissleAmmo) 
		{
			return false;
		}
		else
		{
			MissleAmmo = Mathf.Min (maxMissleAmmo,MissleAmmo+ammount);
			return true;
		}
		
	}

	public bool loseFlyingAmmo(float ammount)
	{
		FlyingAmmo = FlyingAmmo - ammount;
		if (MissleAmmo >= 0) 
		{
			return true;
		} 
		else 
		{
			FlyingAmmo=FlyingAmmo+ammount;
			return false;
		}
	}
	
	public bool gainFlyingAmmo(float ammount)
	{
		
		if (FlyingAmmo == maxFlyingAmmo) 
		{
			return false;
		}
		else
		{
			FlyingAmmo = Mathf.Min (maxFlyingAmmo,FlyingAmmo+ammount);
			return true;
		}
		
	}


	public bool loseBombAmmo(float ammount)
	{
		BombAmmo = BombAmmo - ammount;
		if (BombAmmo >= 0) 
		{
			return true;
		} 
		else 
		{
			BombAmmo=BombAmmo+ammount;
			return false;
		}
	}
	
	public bool gainBombAmmo(float ammount)
	{
		if (BombAmmo == maxBombAmmo) 
		{
			return false;
		}
		else
		{
			BombAmmo = Mathf.Min (maxBombAmmo,BombAmmo+ammount);
			return true;
		}
		
	}

	public bool loseHomingAmmo(float ammount)
	{
		HomingAmmo = HomingAmmo - ammount;
		if (HomingAmmo >= 0) 
		{
			return true;
		} 
		else 
		{
			HomingAmmo=HomingAmmo+ammount;
			return false;
		}
	}
	
	public bool gainHomingAmmo(float ammount)
	{
		if (HomingAmmo == maxHomingAmmo) 
		{
			return false;
		}
		else
		{
			HomingAmmo = Mathf.Min (maxHomingAmmo,HomingAmmo+ammount);
			return true;
		}
		
	}

	
	public float getArmor()
	{
		return armor;
	}
	public bool gainArmor(float ammount)
	{
		if (armor == maxArmor) 
		{
			return false;
		}
		else
		{
			armor = Mathf.Min (maxArmor,armor+ammount);
			return true;
		}

	}

	public float loseArmor(float ammount)
	{
		if (godMode) {
			return 0;
				}
		armor = armor - ammount;
		if (armor < 0) 
		{
			float returnVal = Mathf.Abs(armor);
			armor = 0;
			return (returnVal);
		} 
		else 
		{
			return 0;
		}

	}

}
