using UnityEngine;
using System.Collections;

public class Weapon4PrimCH : MonoBehaviour {
	
	
	public GUIStyle style = new GUIStyle();
	float height;
	float width;
	
	public void activate()
	{
		this.enabled = true;
	}
	
	public void deactivate()
	{
		this.enabled = false;
	}
	
	// Use this for initialization
	void Start () {
		height = gameObject.GetComponentInParent<Canvas>().pixelRect.height;
		width = gameObject.GetComponentInParent<Canvas>().pixelRect.width;
		style.normal.textColor = Color.white;
		style.fontSize = 14;
		
	}
	
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		GUI.Label (new Rect (width / 2-5+21, height / 2-7, 10, 10), "O",style);
		GUI.Label (new Rect (width / 2-5-22, height / 2-7, 10, 10), "O",style);
		//GUI.Label (new Rect (width / 2-5, height / 2-10+5, 10, 10), "\\",style);
		//GUI.Label (new Rect (width / 2-5+5, height / 2-10-5, 10, 10), "\\",style);
	}
}
