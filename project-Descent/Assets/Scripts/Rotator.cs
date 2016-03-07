/*
Author: Gregory Campbell
Function: Continuously rotates an object to make it more visually appealing
Resources: Unity Roll-a-ball tutorial
*/

using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour {

	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
