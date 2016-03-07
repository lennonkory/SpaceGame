using UnityEngine;
using System.Collections;

/*
Author: Mitchell Cook
Function: This class handles the movement of the player. 
It reads the player's input from Unity's input manager 
and using the angles of the player it applies a force to the player.
Resources: NA
*/
public class CharacterMovement2 : MonoBehaviour {
	
	public float speed=2;
	
	public float maxXSpeed=10.0f;
	public float maxYSpeed=10.0f;
	public float maxZSpeed=10.0f;
	

	public float deccelerate=0.5f;
	
	private float Var1;
	private float Var2;
	private float Var3;
	private float Force1;
	private float Force2;
	private float Force3;
	
	private Vector3 vector;
	private float boostTime=0;
	
	private Vector3 l = new Vector3(0,0,0);
	
	private float nextBoost=0.0f;

	public bool stunned = false;

	void Start ()
	{
	}
	void FixedUpdate ()
	{	
		Force2 = 0;

		Var1 = GetComponent<Rigidbody>().rotation.eulerAngles.y;
		Var2 = GetComponent<Rigidbody>().rotation.eulerAngles.x;
	
		//move up(space)
		if (Input.GetAxis ("Yaxis") > 0) 
		{
			Force2 = Force2+1;
		}
		
		//move down(ctrl)
		if (Input.GetAxis ("Yaxis") < 0) 
		{
			Force2 = Force2-1;
		}
		
		//m = (a^2+b^2+c^2)^-1
		//a = (m^2-b^2-c^2)^-1
		
		//move forward
		if (Input.GetAxis ("Zaxis") > 0) {
						Force1 = Mathf.Sin (Mathf.Deg2Rad * Var1);
						Force2 = Force2 + -Mathf.Sin (Mathf.Deg2Rad * Var2);
						Force3 = Mathf.Cos (Mathf.Deg2Rad * Var1);
			
				} else if (Input.GetAxis ("Zaxis") < 0) {
						Force1 = -Mathf.Sin (Mathf.Deg2Rad * Var1);
						Force2 = Force2 + Mathf.Sin (Mathf.Deg2Rad * Var2);
						Force3 = -Mathf.Cos (Mathf.Deg2Rad * Var1);
			
				} else {
			Force1=0;
			Force3=0;
				}
		//move left(a)
		if (Input.GetAxis("Xaxis")<0) 
		{
			Var1 = Var1 + 90;
			if (Var1>360)
			{
				Var1=Var1-360;
			}
			Force1 = Force1+ -Mathf.Sin(Mathf.Deg2Rad *Var1);
			Force3 = Force3+ -Mathf.Cos(Mathf.Deg2Rad *Var1);
			
		}
		
		//move right(d)
		else if (Input.GetAxis("Xaxis")>0) 
		{
			Var1 = Var1-90;
			if (Var1<0)
			{
				Var1=Var1+360;
			}
			Force1 = Force1+ -Mathf.Sin(Mathf.Deg2Rad *Var1);
			Force3 = Force3+ -Mathf.Cos(Mathf.Deg2Rad *Var1);
			
		}
		
		if (Mathf.Abs (Force2) < 0.2)
			Force2 = 0;

		if (Input.GetButtonDown("Boost") && Time.time>nextBoost)
		{
			maxXSpeed =50;
			maxYSpeed =50;
			maxZSpeed =50;
			boostTime=Time.time+0.5f;
			vector = new Vector3(Force1,Force2,Force3);
			//float magnitude = vector.magnitude;
			if (Mathf.Abs(Force3)>Mathf.Abs(Force1))
			{
				if (Force1!=0)	
					vector.x = Mathf.Sqrt(Mathf.Pow(vector.magnitude*5,2)-Mathf.Pow(vector.y,2)-Mathf.Pow(vector.z,2));
				if (Force2!=0)	
					vector.y = Mathf.Sqrt(Mathf.Pow(vector.magnitude*2,2)-Mathf.Pow(vector.x,2)-Mathf.Pow(vector.z,2));
				if (Force3!=0)	
					vector.z = Mathf.Sqrt(Mathf.Pow(vector.magnitude*5,2)-Mathf.Pow(vector.y,2)-Mathf.Pow(vector.x,2));
			}
			else{
				if (Force3!=0)	
					vector.z = Mathf.Sqrt(Mathf.Pow(vector.magnitude*5,2)-Mathf.Pow(vector.y,2)-Mathf.Pow(vector.x,2));
				if (Force2!=0)	
					vector.y = Mathf.Sqrt(Mathf.Pow(vector.magnitude*2,2)-Mathf.Pow(vector.x,2)-Mathf.Pow(vector.z,2));
				if (Force1!=0)	
					vector.x = Mathf.Sqrt(Mathf.Pow(vector.magnitude*5,2)-Mathf.Pow(vector.y,2)-Mathf.Pow(vector.z,2));

			}
			if (Force1<0)
				vector.x=-vector.x;
			if (Force2<0)
				vector.y=-vector.y;
			if (Force3<0)
				vector.z=-vector.z;

			GetComponent<Rigidbody>().AddForce(vector*speed);
			nextBoost=Time.time+5;
		}
		
		//continue boosting
		if (boostTime > Time.time) {
			GetComponent<Rigidbody>().AddForce (vector*speed);
		} 
		//slow down after boost
		else {
			l = new Vector3 (GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
			if (Mathf.Abs (GetComponent<Rigidbody>().velocity.x) > maxXSpeed * 1.5f) {
				l.x = GetComponent<Rigidbody>().velocity.x / 5.0f;
			}
			else
				maxXSpeed=20;
			if (Mathf.Abs (GetComponent<Rigidbody>().velocity.y) > maxYSpeed * 1.5f) {
				l.y = GetComponent<Rigidbody>().velocity.y / 5.0f;
			}
			else
				maxYSpeed=20;
			if (Mathf.Abs (GetComponent<Rigidbody>().velocity.z) > maxZSpeed * 1.5f) {
				l.z = GetComponent<Rigidbody>().velocity.z / 5.0f;
			}
			else
				maxZSpeed=20;
			GetComponent<Rigidbody>().velocity = l;
		}

		if (Force1>0)
			Force1 = Mathf.Min (1.0f, Force1);
		else
			Force1 = Mathf.Max (-1.0f, Force1);
		
		if (Force2>0)
			Force2 = Mathf.Min (1.0f, Force2);
		else
			Force2 = Mathf.Max (-1.0f, Force2);

		if (Force3>0)
			Force3 = Mathf.Min (1.0f, Force3);
		else
			Force3 = Mathf.Max (-1.0f, Force3);
		

		if (stunned ) {
			Force1=0;
			Force2=0;
			Force3=0;
			
				//if the player is not pressing a Key, slow the player down
				//if the players speed falls below a threshold, stop the player completely
				if (GetComponent<Rigidbody>().velocity.magnitude <0.25f)
				{
					GetComponent<Rigidbody>().velocity = (new Vector3(0,0,0));
				}
				else{
					GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity*-deccelerate);
				}
			return;
		}

		else if (Input.GetButton("Xaxis") || Input.GetButton("Zaxis")||Input.GetButton("Yaxis"))	
		{
			//if the player is trying to go in a different direction than they are travelling increase the speed they are going to
			if ((Force3>0 && GetComponent<Rigidbody>().velocity.z <0) || (Force3 <0 && GetComponent<Rigidbody>().velocity.z >0))
			{
				Force3= Force3 *4;
			}
			if ((Force1>0 && GetComponent<Rigidbody>().velocity.x <0) || (Force1<0 && GetComponent<Rigidbody>().velocity.x >0))
			{
				Force1= Force1 *4;
			}
			if ((Force2>0 && GetComponent<Rigidbody>().velocity.y <0) || (Force2<0 && GetComponent<Rigidbody>().velocity.y >0))
			{
				Force2= Force2 *4;
			}
			if (Force1>1 && Force3>1)
			{
				if (Force1>Force3)
				{
					Force1=Force1*2;
				}
				else if (Force1<Force3)
				{
					Force3=Force3*2;
				}
			}
			//apply force to the player to move them.
			if (Force2==0)
			{
				if (GetComponent<Rigidbody>().velocity.magnitude<3)
					GetComponent<Rigidbody>().AddForce(new Vector3(Force1*speed*speed,GetComponent<Rigidbody>().velocity.y*-(deccelerate*2),Force3*speed*speed));
				else
					GetComponent<Rigidbody>().AddForce(new Vector3(Force1*speed,GetComponent<Rigidbody>().velocity.y*-(deccelerate*2),Force3*speed));
			}
			else
				if (GetComponent<Rigidbody>().velocity.magnitude<3)
					GetComponent<Rigidbody>().AddForce (new Vector3 (Force1,Force2,Force3) * speed*speed);
				else
					GetComponent<Rigidbody>().AddForce (new Vector3 (Force1,Force2,Force3) * speed);
			//limit the speed to the max speeds
			float velx =GetComponent<Rigidbody>().velocity.x;
			if (velx<0)
			{
				velx = Mathf.Max (velx,-maxXSpeed);
			}
			else
			{
				velx = Mathf.Min (velx,maxXSpeed);
			}
			float vely =GetComponent<Rigidbody>().velocity.y;
			if (velx<0)
			{
				vely = Mathf.Max (vely,-maxYSpeed);
			}
			else
			{
				vely = Mathf.Min (vely,maxYSpeed);
			}
			float velz =GetComponent<Rigidbody>().velocity.z;
			if (velz<0)
			{
				velz = Mathf.Max (velz,-maxZSpeed);
			}
			else
			{
				velz = Mathf.Min (velz,maxZSpeed);
			}
			GetComponent<Rigidbody>().velocity = new Vector3(velx,vely,velz);
		}
		else {
			//if the player is not pressing a Key, slow the player down
			//if the players speed falls below a threshold, stop the player completely
			if (GetComponent<Rigidbody>().velocity.magnitude <0.25f)
			{
				GetComponent<Rigidbody>().velocity = (new Vector3(0,0,0));
			}
			else{
				GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity*-deccelerate);
			}
		}
		
	}
}
