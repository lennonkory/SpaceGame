using UnityEngine;
using System.Collections;

[System.Serializable]
public class Testing
{
	public float a,b,c;
}

public class CharacterMovement: MonoBehaviour {
	public Testing testing;

	private float temp;

	public float speed;
	public float acceleration = 5;

	public float maxXSpeed=10.0f;
	public float maxYSpeed=10.0f;
	public float maxZSpeed=10.0f;

	public float xAngle;
	public float yAngle; 
	public float zAngle;
	public float xVector;
	public float yVector;
	public float zVector;

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		float x = transform.eulerAngles.y;
		if (Input.GetKey (KeyCode.A)) {
			if (x >85 && x <95){
				moveHorizontal = 1;
			}
		} 
		else if (Input.GetKey (KeyCode.D)) {
			x = x +90;
			if (x > 360)
			{
				x = x -360;
			}
				}
		if (x >= 0 && x <= 90) {
			x = x;
				} 
		else if (x >= 90 && x <= 180) {
			x = Mathf.Abs(180-x);
		}
		else if (x >= 180 && x <=270) {
			x = 0-Mathf.Abs(180-x);
		} 
		else if (x >= 270 && x <=360) {
			x = x-360;
		}

		x = (x / 180)*acceleration;

		float z = transform.eulerAngles.z;

		float y = transform.eulerAngles.x;
		if (y < 180) {
			y = 0 - y;
				} 
		else if (y > 180) {
			y = 360-y;
				}
		y = (y / 180)*1.5f*acceleration;

		


		if (Input.GetKey(KeyCode.A))
		{
			 
			temp = x;
			x = moveHorizontal;
			moveHorizontal=temp;
			//rigidbody.AddForce(new Vector3(testing.a,testing.b,testing.c)*speed);//,
			                             //new Vector3(rigidbody.position.x+1.0f,rigidbody.position.y,rigidbody.position.z));
			//moveVertical=1.00f;
			//x = 0;
			//move left, x = -1?
		}

		if (Input.GetKey (KeyCode.D)) 
		{
			
			temp = x;
			x = moveHorizontal;
			moveHorizontal=temp;
			//move right x = 1?
		}

		if (Input.GetKey(KeyCode.W)) {
			if (Mathf.Abs(transform.eulerAngles.y)<90 || Mathf.Abs(transform.eulerAngles.y)>270){
				moveVertical = 1.00f*acceleration/3;
			}
			else {
				moveVertical= -1.00f*acceleration/3;
			}
		}
		if (Input.GetKey(KeyCode.S))
		{
			if (Mathf.Abs(transform.eulerAngles.y)<90 || Mathf.Abs(transform.eulerAngles.y)>270){
				moveVertical = -1.00f*acceleration/3;
				x = -x;
				y = -y;
			}
			else {
				moveVertical= 1.00f*acceleration/3;
				x = -x;
				y = -y;
			}
		}


		if (Input.GetKey (KeyCode.Space)) {
			y = 1;
				}
		if (Input.GetKey (KeyCode.LeftControl)) {
			y = -1;
		}

		//experimental
		if (Input.GetKey(KeyCode.X))
		{
			xAngle = GetComponent<Rigidbody>().rotation.eulerAngles.x;
			yAngle = GetComponent<Rigidbody>().rotation.eulerAngles.y; 
			zAngle = GetComponent<Rigidbody>().rotation.z;
			speed = 10;

			xVector = -(Mathf.Sin(xAngle*Mathf.PI/180));
			yVector = (Mathf.Sin(yAngle*Mathf.PI/180));

			zVector = speed*Mathf.Sin(zAngle);

			print ("xAngle: "+xAngle+"yAngle: "+yAngle);
			print ("xVector: "+xVector+"yVector: "+yVector);

			GetComponent<Rigidbody>().AddForce (new Vector3 (yVector, xVector, moveVertical));

		}
		else if (Input.anyKey) {

			//if the player is trying to go in a different direction than they are travelling increase the speed they are going to
			if ((moveVertical>0 && GetComponent<Rigidbody>().velocity.z <0) || (moveVertical<0 && GetComponent<Rigidbody>().velocity.z >0))
			{
				moveVertical= moveVertical *3;
			}
			if ((x>0 && GetComponent<Rigidbody>().velocity.x <0) || (x<0 && GetComponent<Rigidbody>().velocity.x >0))
			{
				x= x *3;
			}
			if ((y>0 && GetComponent<Rigidbody>().velocity.y <0) || (y<0 && GetComponent<Rigidbody>().velocity.y >0))
			{
				y= y *3.5f;
			}
			/*
			//limmit the max speed of the player to the set values
			if (rigidbody.velocity.x+(x*speed)>maxXSpeed)
			{
				x = 0.0f;
			}
			if (rigidbody.velocity.y+(y*speed)>maxYSpeed)
			{
				x = 0.0f;
			}
			if (rigidbody.velocity.z+(moveVertical*speed)>maxZSpeed)
			{
				x = 0.0f;
			}*/

			//apply the force, moves the player
			//rigidbody.AddForce (new Vector3 (testing.a,testing.b,testing.c) * speed);
			GetComponent<Rigidbody>().AddForce (new Vector3 (x, y, moveVertical) * speed);
		}
		else {
			//if the player is not pressing a Key, slow the player down
			//if the players speed falls below a threshold, stop the player completely
			if (GetComponent<Rigidbody>().velocity.magnitude <0.25f)
			{
				GetComponent<Rigidbody>().velocity = (new Vector3(0,0,0));
			}
			else{
			GetComponent<Rigidbody>().AddForce(GetComponent<Rigidbody>().velocity*-.3f);
			}
				}
	}
}
