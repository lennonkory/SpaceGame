using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the various UIs the player can 
have and what UI are active or not. Certain classes will cause 
certain UIs to either activate or deactivate. Anything that 
happens when a UI is activated/deactivated is handled in that 
specific UI. 
Resources: NA
*/

public class UIStateController : MonoBehaviour {

	UIDisrupted disrupted;
	UIDisplayHealth normal;
	CompleteUI complete;
	PauseUI pause;
	CrosshairUI weapon0PCH;
	Weapon1PrimCH weapon1PCH;
	Weapon2PrimCH weapon2PCH;
	Weapon3PrimCH weapon3PCH;
	Weapon4PrimCH weapon4PCH;
	Weapon0SecCH weapon0SCH;
	Weapon1SecCH weapon1SCH;
	Weapon2SecCH weapon2SCH;
	Weapon3SecCH weapon3SCH;



	bool pauseCheck = false;
	bool objectiveCheck = false;
	bool disruptedCheck = false;
	Weapons weaponPrim;
	Weapons weaponSec;

	// Use this for initialization
	void Start () {
		disrupted 	= GetComponentInChildren<Canvas> ().GetComponentInChildren<UIDisrupted> ();
		normal 		= GetComponentInChildren<Canvas> ().GetComponentInChildren<UIDisplayHealth> ();
		complete 	= GetComponentInChildren<Canvas> ().GetComponentInChildren<CompleteUI> ();
		pause 		= GetComponentInChildren<Canvas> ().GetComponentInChildren<PauseUI> ();
		weapon0PCH = GetComponentInChildren<Canvas> ().GetComponentInChildren<CrosshairUI> ();
		weapon1PCH = GetComponentInChildren<Canvas> ().GetComponentInChildren<Weapon1PrimCH> ();
		weapon2PCH = GetComponentInChildren<Canvas> ().GetComponentInChildren<Weapon2PrimCH> ();
		weapon0SCH = GetComponentInChildren<Canvas> ().GetComponentInChildren<Weapon0SecCH> ();
		weapon1SCH = GetComponentInChildren<Canvas> ().GetComponentInChildren<Weapon1SecCH> ();
		weapon2SCH = GetComponentInChildren<Canvas> ().GetComponentInChildren<Weapon2SecCH> ();
		weapon3SCH = GetComponentInChildren<Canvas> ().GetComponentInChildren<Weapon3SecCH> ();
		weapon3PCH = GetComponentInChildren<Canvas> ().GetComponentInChildren<Weapon3PrimCH> ();
		weapon4PCH = GetComponentInChildren<Canvas> ().GetComponentInChildren<Weapon4PrimCH> ();
	}


	public void pauseToggle()
	{
		pauseCheck = !pauseCheck;
	}

	public void objectiveToggle()
	{
		objectiveCheck = !objectiveCheck;
	}

	public void disruptedToggle()
	{
		disruptedCheck = !disruptedCheck;
	}

	public void disruptedSet()
	{
		disruptedCheck = true;
	}
	public void disruptedReset()
	{
		disruptedCheck = false;
	}

	// Update is called once per frame
	void Update () {
		weaponPrim = GetComponent<PlayerController> ().weaponPrim;
		weaponSec = GetComponent<PlayerController> ().weaponSec;

		if (weaponPrim.getName ().Equals ("Capsule")) {
						weapon0PCH.activate ();
						weapon1PCH.deactivate ();
						weapon2PCH.deactivate ();
						weapon3PCH.deactivate ();
			weapon4PCH.deactivate();
		} else if (weaponPrim.getName ().Equals ("Fire")) {
						weapon1PCH.activate ();
						weapon0PCH.deactivate ();
						weapon2PCH.deactivate ();
						weapon3PCH.deactivate ();
			weapon4PCH.deactivate();
		} else if (weaponPrim.getName ().Equals ("Laser")) {
						weapon2PCH.activate ();
						weapon1PCH.deactivate ();
						weapon0PCH.deactivate ();
						weapon3PCH.deactivate ();
			weapon4PCH.deactivate();
		} else if (weaponPrim.getName ().Equals ("CapFire")) {
						weapon3PCH.activate ();
						weapon1PCH.deactivate ();
						weapon0PCH.deactivate ();
						weapon2PCH.deactivate ();
			weapon4PCH.deactivate();
				} else if (weaponPrim.getName ().Equals ("Small")) {
			weapon4PCH.activate ();
			weapon3PCH.deactivate ();
			weapon1PCH.deactivate ();
			weapon0PCH.deactivate ();
			weapon2PCH.deactivate ();

				}

		if (weaponSec.getName().Equals("Big")) {
			weapon0SCH.activate();
			weapon1SCH.deactivate();
			weapon3SCH.deactivate();
			weapon2SCH.deactivate();
		}
		else if (weaponSec.getName().Equals("Bomb")) {
			weapon1SCH.activate();
			weapon0SCH.deactivate();
			weapon3SCH.deactivate();
			weapon2SCH.deactivate();
		}
		else if (weaponSec.getName().Equals("Homing")) {
			weapon2SCH.activate();
			weapon1SCH.deactivate();
			weapon3SCH.deactivate();
			weapon0SCH.deactivate();}
		else if (weaponSec.getName().Equals("FlyingBomb")) {
			weapon3SCH.activate();
			weapon2SCH.deactivate();
			weapon1SCH.deactivate();
			weapon0SCH.deactivate();}
		
		
		if (pauseCheck) {
			pause.activate ();
			weapon0PCH.deactivate();
			weapon0SCH.deactivate();
			weapon1PCH.deactivate();
			weapon1SCH.deactivate();
			weapon2PCH.deactivate();
			weapon2SCH.deactivate();
			weapon3PCH.deactivate();
		}
		else if (objectiveCheck) {
			complete.activate ();
		} 
		else if (!pauseCheck){
			pause.deactivate();
		}
		else if (!objectiveCheck) {
			complete.deactivate();
		}

		if (disruptedCheck) {
			disrupted.activate ();
			normal.deactivate();
			weapon0PCH.deactivate();
			weapon0SCH.deactivate();
			weapon1PCH.deactivate();
			weapon1SCH.deactivate();
			weapon2PCH.deactivate();
			weapon2SCH.deactivate();
		} else {
			disrupted.deactivate();
			normal.activate();
		}


	}
}
