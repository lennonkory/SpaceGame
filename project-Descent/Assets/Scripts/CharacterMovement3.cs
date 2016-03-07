using UnityEngine;
using System.Collections;

public class CharacterMovement3 : MonoBehaviour {

	public float speed=2;
	
	public float maxXSpeed=10.0f;
	public float maxYSpeed=10.0f;
	public float maxZSpeed=10.0f;
	
	public int zoomDistance=20;
	
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
	
	private Camera camera;
	
	private float nextBoost=0.0f;

	// Use this for initialization
	void Start () {
		camera = GetComponentInChildren<Camera> ();

	}


	public void forward()
	{
		Var1 = GetComponent<Rigidbody>().rotation.eulerAngles.y;
		Var2 = GetComponent<Rigidbody>().rotation.eulerAngles.x;

		Force1 = Mathf.Sin(Mathf.Deg2Rad *Var1);
		Force2 =Force2+ -Mathf.Sin(Mathf.Deg2Rad * Var2);
		Force3 = Mathf.Cos(Mathf.Deg2Rad *Var1);

		move ();
	}

	public void backwards()
	{
		Var1 = GetComponent<Rigidbody>().rotation.eulerAngles.y;
		Var2 = GetComponent<Rigidbody>().rotation.eulerAngles.x;

		Force1 = -Mathf.Sin(Mathf.Deg2Rad *Var1);
		Force2 = Force2+ Mathf.Sin(Mathf.Deg2Rad * Var2);
		Force3 = -Mathf.Cos(Mathf.Deg2Rad *Var1);

		move ();
	}

	public void strafeLeft()
	{
		Var1 = GetComponent<Rigidbody>().rotation.eulerAngles.y;
		Var2 = GetComponent<Rigidbody>().rotation.eulerAngles.x;

		Var1 = Var1 + 90;
		if (Var1>360)
		{
			Var1=Var1-360;
		}
		Force1 = Force1+ -Mathf.Sin(Mathf.Deg2Rad *Var1);
		Force3 = Force3+ -Mathf.Cos(Mathf.Deg2Rad *Var1);

		move ();
	}

	
	public void strafeRight()
	{
		Var1 = GetComponent<Rigidbody>().rotation.eulerAngles.y;
		Var2 = GetComponent<Rigidbody>().rotation.eulerAngles.x;
		
		Var1 = Var1-90;
		if (Var1<0)
		{
			Var1=Var1+360;
		}
		Force1 = Force1+ -Mathf.Sin(Mathf.Deg2Rad *Var1);
		Force3 = Force3+ -Mathf.Cos(Mathf.Deg2Rad *Var1);

		move ();
	}



	void move()
	{
		if (Input.GetButtonDown("Boost") && Time.time>nextBoost)
		{
			boostTime=Time.time+0.5f;
			vector = new Vector3(Force1,Force2,Force3);
			vector.x = Mathf.Sqrt(Mathf.Pow(vector.magnitude*5,2)-Mathf.Pow(vector.y,2)-Mathf.Pow(vector.z,2));
			vector.y = Mathf.Sqrt(Mathf.Pow(vector.magnitude*2,2)-Mathf.Pow(vector.x,2)-Mathf.Pow(vector.z,2));
			vector.z = Mathf.Sqrt(Mathf.Pow(vector.magnitude*5,2)-Mathf.Pow(vector.y,2)-Mathf.Pow(vector.x,2));
			if (Force1<0)
				vector.x=-vector.x;
			if (Force2<0)
				vector.y=-vector.y;
			if (Force3<0)
				vector.z=-vector.z;
			GetComponent<Rigidbody>().AddForce(vector);
			nextBoost=Time.time+5;
		}

		
		if (Force1>0)
			Force1 = Mathf.Min (1.0f, Force1);
		else
			Force1 = Mathf.Max (-1.0f, Force1);
		
		if (Force2>0)
			Force2 = Mathf.Min (1.0f, Force2);
		else
			Force2 = Mathf.Max (-1.0f, Force2);
		
		if (Mathf.Abs (Force2) < 0.2)
			Force2 = 0;
		
		
		if (Force3>0)
			Force3 = Mathf.Min (1.0f, Force3);
		else
			Force3 = Mathf.Max (-1.0f, Force3);
		
		//continue boosting

		if (Input.GetButton("Xaxis") || Input.GetButton("Zaxis")||Input.GetButton("Yaxis"))	
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
			
			//limmit the max speed of the player to the set values
			if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x+(Force1*speed))>maxXSpeed)
			{
				Force1 = 0.0f;
			}
			if (Mathf.Abs(GetComponent<Rigidbody>().velocity.y+(Force2*speed))>maxYSpeed)
			{
				Force2 = 0.0f;
			}
			if (Mathf.Abs(GetComponent<Rigidbody>().velocity.z+(Force3*speed))>maxZSpeed)
			{
				Force3 = 0.0f;
			}
			
			//apply the force, moves the player
			
			if (Force2==0)
				GetComponent<Rigidbody>().AddForce(new Vector3(Force1,GetComponent<Rigidbody>().velocity.y*-(deccelerate*2),Force3));
			else
				GetComponent<Rigidbody>().AddForce (new Vector3 (Force1,Force2,Force3) * speed);
			
		}
		Force1 = 0;
		Force2 = 0;
		Force3 = 0;

	}

	// Update is called once per frame
	void Update () {
		if (boostTime > Time.time) {
			GetComponent<Rigidbody>().AddForce (vector);
		} 
		//slow down after boost
		else {
			l = new Vector3 (GetComponent<Rigidbody>().velocity.x, GetComponent<Rigidbody>().velocity.y, GetComponent<Rigidbody>().velocity.z);
			if (Mathf.Abs (GetComponent<Rigidbody>().velocity.x) > maxXSpeed * 1.5f) {
				l.x = GetComponent<Rigidbody>().velocity.x / 5.0f;
			}
			if (Mathf.Abs (GetComponent<Rigidbody>().velocity.y) > maxYSpeed * 1.5f) {
				l.y = GetComponent<Rigidbody>().velocity.y / 5.0f;
			}
			if (Mathf.Abs (GetComponent<Rigidbody>().velocity.z) > maxZSpeed * 1.5f) {
				l.z = GetComponent<Rigidbody>().velocity.z / 5.0f;
			}
			GetComponent<Rigidbody>().velocity = l;
		}

	}
}
