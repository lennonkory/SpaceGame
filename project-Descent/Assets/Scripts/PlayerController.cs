using UnityEngine;
using System.Collections;

/*
Author:Kory Bryson, Mitchell Cook
Function: Main control script for firing weapons. Variables are public for testing. This script mainly controllers
the selection of weapons and the firing of weapons. It relays on the Class Weapons for adjusting firerate, damage etc.
Resources: General idea taken from space shooter.(Mainly just how a weapon is fired)
*/
using System;

public class PlayerController : MonoBehaviour {

	//primary and secondary weapons are handled separately
	public Weapons weaponPrim;
	public Weapons weaponSec;

	//The objects as they appear in the game

	public GameObject primaryShot;
	public GameObject secondaryShot;

	public GameObject pickUpSound;

	public Transform shotSpawn;//where the projectile comes from
	public Transform shotSpawnLeft;
	public Transform shotSpawnRight;
	public Transform secSpawn;//where the secondary weapon comes from
	public WeaponController weaponController;//Sets which weapon is which

	private int primWeapNum = 0;//What weapon the player is using
	private int secWeapNum = 0;//What weapon the player is using

	private int bombCount = 0;
	private GameObject flyingBomb = null;

	//PlayerStats are needed as its up to the player to control how much ammo they have
	private PlayerStats stats;

	//A reference to the main camera of the game. Used primarily to zoom/adjust FOV 
	private Camera cam;
	public int zoomDistance = 20;

	void Start()
	{
		cam = GetComponentInChildren<Camera> ();
		stats = GetComponent<PlayerStats> ();

		weaponController.setPrimList (stats.usePrimList());
		weaponController.setSecList (stats.useSecList());

		weaponPrim = weaponController.getPrimWeapon (0);
		weaponSec = weaponController.getSecWeapon (0);

		primaryShot = weaponController.getPrimary (0);
		secondaryShot = weaponController.getSecondary (0); 

		primaryShot.gameObject.SetActive(true);
		secondaryShot.gameObject.SetActive(true);
	}

	/*Controls what happens when a player tries to fire or switch weapons*/
	void Update ()
	{

		if (Input.GetKeyDown (KeyCode.Escape)) {
			GetComponent<UIStateController>().pauseToggle();
			weaponPrim.nextFire=Time.time+.02f;
			weaponSec.nextFire=Time.time+.02f;
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			GetComponent<Rigidbody>().GetComponent<Collider>().isTrigger = !GetComponent<Rigidbody>().GetComponent<Collider>().isTrigger;
		}
		if (Input.GetKeyDown (KeyCode.K)) {
				gameObject.GetComponent<PlayerState2>().GodMode();
		}
		PlayerState2 state = gameObject.GetComponent<PlayerState2> ();
		if (Input.GetKeyDown (KeyCode.Y)) {
			if (state.isState("Fire")==false)
			state.addState(new FireState(1,1000,stats));
			else
				state.removeState("Fire");
		}
		if (Input.GetKeyDown (KeyCode.U)) {
			if (state.isState("Slow")==false)
				state.addState(new SlowState(30,1000,gameObject));
			else
				state.removeState("Slow");
		}
		if (Input.GetKeyDown (KeyCode.H)) {
			if (state.isState("Disrupted")==false)
				state.addState(new DisruptedState(1000));
			else
				state.removeState("Disrupted");
		}
		if (Input.GetKeyDown (KeyCode.J)) {
			if (state.isState("Invincibility")==false)
			state.addState(new InvincibilityState(1000));
			else
				state.removeState("Invincibility");
		}
		if (Input.GetKeyDown (KeyCode.I)) {
			if (state.isState("Stunned")==false)
			state.addState(new StunnedState(1000));
			else
				state.removeState("Stunned");
		}

		
		//zoom
		if (Input.GetButton ("Zoom")) {
			if (cam.fieldOfView >= zoomDistance)
			{
				
				cam.fieldOfView= cam.fieldOfView-5;
			}
		} 
		else 
		{
			cam.fieldOfView = 60;
		}

		if(weaponPrim.getName().Equals("Laser")){

			if (Input.GetButton("Fire1")) 
			{
				if (stats.loseEnergy(weaponPrim.energy)==false)
				{
					print("Out of Energy");					
					turnOffLaser();
					return;
				}
				NewFireLaser();
			}
			else{
				primaryShot.SetActive(false);
			}

		}
		else{

			//Primary fire
			if (Input.GetButton("Fire1") && Time.time > weaponPrim.nextFire) 
			{

				if (stats.loseEnergy(weaponPrim.energy)==false)
				{
					print("Out of Energy");
					return;
				}

				else{
					if(weaponPrim.getName().Equals("Small")){
						try{
							weaponPrim.nextFire = Time.time + weaponPrim.fireRate;
							Instantiate(primaryShot, shotSpawnLeft.position, shotSpawnLeft.rotation);
							Instantiate(primaryShot, shotSpawnRight.position, shotSpawnRight.rotation);
						}
						catch(Exception e){
							print(e);
						}
					}
					else{
						try{
							weaponPrim.nextFire = Time.time + weaponPrim.fireRate;
							Instantiate(primaryShot, shotSpawn.position, shotSpawn.rotation);
						}
						catch(Exception e){
							print(e);
						}
					}

				}
			}
		}

		//Secondary fire
		if (Input.GetButtonDown("Fire2") && Time.time > weaponSec.nextFire) 
		{

			if(weaponSec.getName().Equals("FlyingBomb")){
				if(flyingBomb == null){
					if (stats.loseAmmo(1)==false)
					{
						print ("Out of ammo");
						return;
					}
					flyingBomb = Instantiate(secondaryShot, secSpawn.position, secSpawn.rotation) as GameObject;
				}
				else{
					try{
						flyingBomb.SendMessage("BlowUp",true,SendMessageOptions.DontRequireReceiver);
						flyingBomb = null;
		
					}
					catch(Exception e){
						print(e);
					}
				}
			}
			else{
				try{
					if (stats.loseAmmo(1)==false)
					{
						print ("Out of ammo");
						return;
					}
					weaponSec.nextFire = Time.time + weaponSec.fireRate;
					Instantiate(secondaryShot, secSpawn.position, secSpawn.rotation);
				}
				catch(Exception e){
					print(e);
				}
			}

		}

		//If the player switches weapons
		if (Input.GetButtonDown("Switch"))
		{
			turnOffLaser();
			switchWeapons();
		}
		if (Input.GetButtonDown("SwitchSecondary"))
		{
			switchSecondaryWeapons();
		}
		
		if (Input.GetButtonDown("GetAllWeapons"))
		{
			getAllWeapons();
		}
		if (Input.GetButtonDown("GenerateWeapon"))
		{
			generatePickUp();
		}
	}

	private void NewFireLaser(){
		primaryShot = gameObject.transform.Find("LaserK").gameObject;
		primaryShot.SetActive(true);
	}

	private void turnOffLaser(){
		try{
			GameObject l = GameObject.Find ("LaserK");
			l.SetActive(false);
		}
		catch (NullReferenceException  e){
			string t = e.HelpLink;
			t += "cat";
		}
	}


	/*Weapons are switched in weaponController. This was done because I feel this class is
	more about firing weapons so I wanted another class to take care of switching
	 */
	private void switchWeapons()
	{
		primWeapNum ++;

		primWeapNum = primWeapNum % weaponController.getPrimSize();
		primaryShot = weaponController.getPrimary (primWeapNum);

		weaponPrim = weaponController.getPrimWeapon (primWeapNum);

		primaryShot.gameObject.SetActive(true);

	}

	/*Switches secondary weapons*/
	private void switchSecondaryWeapons()
	{
		secWeapNum ++;
		
		secWeapNum = secWeapNum % weaponController.getSecSize();
		secondaryShot = weaponController.getSecondary (secWeapNum);

		weaponSec = weaponController.getSecWeapon (secWeapNum);
		secondaryShot.gameObject.SetActive(true);
		stats.activeAmmo = secWeapNum;
	}

	void PlayPickupSound()
	{
		Instantiate(pickUpSound, transform.position, transform.rotation);
	}

	void addToPrimaryPlayer(String pickup)
	{
		try{
			GameObject go = (Resources.Load (pickup) as GameObject);
			bool add = weaponController.addToPrimary (go);

			if(!add){
				stats.gainEnergy(20);
			}

		}
		catch (NullReferenceException e){
			print("Could not find weapon: " + pickup + " " + e.Message);
		}
		PlayPickupSound ();

	}

	void addToSecondaryPlayer(String pickup)
	{
	
		try{
			GameObject go = (Resources.Load (pickup) as GameObject);
			bool add = weaponController.addToSecondary (go);
			if(!add){
				addToAmmo(pickup);
			}
		}
		catch (NullReferenceException e){
			print("Could not find weapon: " + pickup + " " + e.Message);
		}

		PlayPickupSound ();
		
	}

	private void addToAmmo(String ammoType){

		int temp = stats.activeAmmo;

		if(ammoType.Equals("Bomb")){
			stats.activeAmmo = 1;
			stats.gainActiveAmmo(1);
		}
		else if(ammoType.Equals("Homing")){
			stats.activeAmmo = 2;
			stats.gainActiveAmmo(1);
		}
		else if(ammoType.Equals("Big")){
			stats.activeAmmo = 0;
			stats.gainActiveAmmo(1);
		}

		stats.activeAmmo = temp;
	}

	private void getAllWeapons(){
	
		weaponController.loadAllWeapons();
		
		primaryShot = weaponController.getPrimary (0);

		weaponPrim = weaponController.getPrimWeapon (0);

		primaryShot.gameObject.SetActive(true);
		
		secondaryShot = weaponController.getSecondary (0);

		weaponSec = weaponController.getSecWeapon (0);
		secondaryShot.gameObject.SetActive(true);
		stats.activeAmmo = 0;
	
	}

	private void generatePickUp(){
		Instantiate (Resources.Load("WeaponPickUp") as GameObject,shotSpawn.position,shotSpawn.rotation);
	}

	/*These two methods are more for testing*/
	public string getPrimaryName()
	{
		return weaponPrim.getName ();
	}

	public string getSecondaryName()
	{
		return weaponSec.getName ();
	}
}
