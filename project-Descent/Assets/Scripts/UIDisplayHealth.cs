using UnityEngine;
using System.Collections;
/*
Author:Mitchell Cook
Function: This class displays the player's UI. It includes the 
players stats(health ammo and energy), any status effects on the 
player, the corsshair and the artifical horizon.
Resources: NA
 */
public class UIDisplayHealth : MonoBehaviour {
	
	private PlayerStats stats;
	private float height;
	private float width;

	private PlayerState2 state;
	private State[] stateList;


	private Weapons weapon1;
	private Weapons weapon2;
	
	private string weaponName1="";
	private string weaponName2="";

	private Objective objective;

	private bool left=false;
	private bool right = false;
	private bool front = false;
	private bool behind = false;

	private float hitTimeF=0;
	private float hitTimeL=0;
	private float hitTimeR=0;
	private float hitTimeB=0;


	public GUIStyle styleH = new GUIStyle();
	public GUIStyle styleE = new GUIStyle();
	public GUIStyle styleA = new GUIStyle();
	public GUIStyle styleCross = new GUIStyle();
	public GUIStyle styleAr = new GUIStyle();
	public GUIStyle styleOb = new GUIStyle();
	public void activate()
	{
		this.enabled = true;
	}

	public void deactivate()
	{
		this.enabled = false;
	}

	void Awake()
	{
		styleCross.normal.textColor = Color.white;
		styleCross.fontSize = 20;
		stats = GetComponentInParent<Canvas> ().GetComponentInParent<PlayerStats>();
		state = GetComponentInParent<Canvas> ().GetComponentInParent<PlayerState2>();
		objective = GameObject.Find ("Objective").GetComponent<Objective>();
	}
	public void DamageDirection(Rigidbody body)
	{
	
		Rigidbody thisBody = GetComponentInParent<Canvas> ().GetComponentInParent<Rigidbody> ();
				if (body.position.x > thisBody.position.x) {
						if (thisBody.rotation.eulerAngles.y > 45 && thisBody.rotation.eulerAngles.y < 135) {
								behind = true;
								hitTimeB = Time.time + 1;
						}
						if (thisBody.rotation.eulerAngles.y > 135 && thisBody.rotation.eulerAngles.y < 225) {
								left = true;
								hitTimeL = Time.time + 1;
						}
						if (thisBody.rotation.eulerAngles.y > 225 && thisBody.rotation.eulerAngles.y < 315) {
								front = true;
								hitTimeF = Time.time + 1;
						}
						if (thisBody.rotation.eulerAngles.y > 315 || thisBody.rotation.eulerAngles.y < 45) {
								right = true;
								hitTimeR = Time.time + 1;
						} 
				}else {
								if (thisBody.rotation.eulerAngles.y > 45 && thisBody.rotation.eulerAngles.y < 135) {
										hitTimeF = Time.time + 1;
										front = true;
								}
								if (thisBody.rotation.eulerAngles.y > 135 && thisBody.rotation.eulerAngles.y < 225) {
										hitTimeR = Time.time + 1;
										right = true;
								}
								if (thisBody.rotation.eulerAngles.y > 225 && thisBody.rotation.eulerAngles.y < 315) {
										hitTimeB = Time.time + 1;
										behind = true;
								}
								if (thisBody.rotation.eulerAngles.y > 315 || thisBody.rotation.eulerAngles.y < 45) {	
										hitTimeL = Time.time + 1;
										left = true;
								}
						}
				
		}

	float objectiveTime;
	private string weaponMessage;
	private float weaponTime;
	private bool displayMess;

	public void Start()
	{
		objectiveTime = Time.time;
		weaponTime = Time.time;
		displayMess = false;
		
		styleH.normal.textColor = Color.red;
		styleH.fontSize = 15;
		
		styleE.normal.textColor = Color.blue;
		styleE.fontSize = 15;
		
		styleA.normal.textColor = Color.yellow;
		styleA.fontSize = 15;
		styleAr.normal.textColor = new Color32(200,200,200,255);
		styleAr.fontSize = 15;

		styleOb.normal.textColor = Color.white;
		styleOb.fontSize = 25;

	}

	public void KoryMessage(string message){
		weaponMessage = message;
		weaponTime = Time.time;
		displayMess = true;
	}

	void OnGUI()
	{
		weapon1 = GetComponentInParent<Canvas> ().GetComponentInParent<PlayerController>().weaponPrim;
		weapon2 = GetComponentInParent<Canvas> ().GetComponentInParent<PlayerController>().weaponSec;
		
		weaponName1 = weapon1.getName ();
		weaponName2 = weapon2.getName ();
		
		height = gameObject.GetComponentInParent<Canvas>().pixelRect.height;
		width = gameObject.GetComponentInParent<Canvas>().pixelRect.width;
		
		// kill all enemies
		// find the ball
		if (Time.time-objectiveTime < 5)
		{
			string obj = GameObject.Find("Objective").GetComponent<Objective>().objective.ObjectiveMessage();
			GUI.Label(new Rect(width/2-obj.Length*5,height/4,100,100),obj,styleOb);
		}
		if(Time.time-weaponTime < 3 && displayMess){
		GUI.Label(new Rect(width/2-50,height/3,1000,1000),weaponMessage);
		}


		GUI.Label (new Rect (10, height-20, 75, 20), "Health:"+stats.getHealth(),styleH);
		GUI.Label (new Rect (10, height-40, 75, 20), "Armor:"+stats.getArmor(),styleAr);

		GUI.Label (new Rect (width-90-(weaponName1.Length*9), height-40, 75+1000, 20), weaponName1+"->Energy:"+(int)(stats.getEnergy()),styleE);
		
		GUI.Label (new Rect (width-92-(weaponName2.Length*9), height-20, 75+1000, 20), weaponName2+"->Ammo:"+stats.getAmmo(),styleA);
		

		GUI.Label(new Rect(0+50, height/2-75*Mathf.Sin(GetComponentInParent<Canvas>().GetComponentInParent<Rigidbody>().transform.rotation.eulerAngles.x*Mathf.Deg2Rad), 20, 20), "-",styleCross);
		GUI.Label(new Rect(0+10, height/2-6*GetComponentInParent<Canvas>().GetComponentInParent<Rigidbody>().velocity.y, 20, 20), "-",styleCross);
		
		GUI.Label(new Rect(0+30, height/2-75*Mathf.Sin(80*Mathf.Deg2Rad), 20, 20), "-",styleCross);
		GUI.Label(new Rect(0+30, height/2-75*Mathf.Sin(-80*Mathf.Deg2Rad), 20, 20), "-",styleCross);
		GUI.Label(new Rect(0+30, height/2+15, 20, 20), "-");
		GUI.Label(new Rect(0+30, height/2-15, 20, 20), "-");
		GUI.Label(new Rect(0+30, height/2-75*Mathf.Sin(0), 20, 20), "-",styleCross);

		if (objective.getCompleted ()) {
			GetComponentInParent<Canvas>().GetComponentInChildren<CompleteUI>().enabled=true;
			//GUI.Label(new Rect(width/2, height/2+15, 20, 20), "You Win",styleCross);
		}

			if (left)
				GUI.Label(new Rect(width/2-50,height/2,100,100),"||",styleH);
			if (right)
				GUI.Label(new Rect(width/2+50,height/2,100,100),"||",styleH);
			if (behind)
				GUI.Label(new Rect(width/2,height/2-50,100,100),"__",styleH);
			if (front)
				GUI.Label(new Rect(width/2,height/2+50,100,100),"__",styleH);
		stateList = state.getStates ();
		for (int i =0; i<stateList.Length; i++) {
			if (stateList[i]==null)
				break;
			GUI.Label(new Rect(width-75,0+(i*12),100,100),stateList[i].getState(),styleA);
		}
	}
	void Update()
	{
		if (hitTimeB<Time.time)
		{
			behind = false;
		}
		if (hitTimeF<Time.time)
		{
			front = false;
		}
		if (hitTimeL<Time.time)
		{
			left = false;
		}
		if (hitTimeR<Time.time)
		{
			right = false;
		}
	}
}
