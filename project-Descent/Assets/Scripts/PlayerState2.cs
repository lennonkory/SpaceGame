using UnityEngine;
using System.Collections;
/*
Author: Mitchell Cook
Function: This class handles the states of the player. When the player 
gets a state applied to them it will be handled and held here. Every 
update the states are applied and are removed once their effect ends.
Resources: NA
*/

public class PlayerState2 : MonoBehaviour {

	State[] stateList = new State[15];

	public bool godMode = false;

	public void GodMode()
	{
		for (int i =0; i<15; i++) {
			if (stateList[i]!=null && stateList[i].getState()=="GodMode")
			{
				stateList[i]=null;
				godMode=false;
				gameObject.GetComponent<PlayerStats>().godMode=false;
				return;
			}
				}
		addState(new GodModeState(1000));
		godMode = true;
	}

	public void addState(State state)
	{
		if (godMode) {
			return;
				}
		for (int i =0; i<15; i++) {
			if (stateList[i]==null)
				continue;
			if (stateList[i].getState()=="Slow"&&state.getState()=="Slow")
			{
				stateList[i].updateState(state);
				return;
			}
			else if (stateList[i].getState()=="Stunned" && state.getState()=="Stunned")
			{
				stateList[i].updateState(state);
				return;
			}
			
			else if (stateList[i].getState()=="Disrupted" && state.getState()=="Disrupted")
			{
				stateList[i].updateState(state);
				return;
			}
			
			else if (stateList[i].getState()=="Invincibility" && state.getState()=="Invincibility")
			{
				stateList[i].updateState(state);
				return;
			}

		}
		for (int i =0; i<15; i++) {
			if (stateList[i]==null)
			{
				stateList[i]=state;
				break;
			}

		}
	}
	public bool isState(string state)
	{
		for (int i =0; i<15; i++) {
			if (stateList[i]!=null && stateList[i].getState()==state)
			{
				return true;
			}

		}
		return false;
	}

	public bool removeState(string state)
	{
		for (int i =0; i<15; i++) {
			if (stateList[i]!=null && stateList[i].getState()==state)
			{
				stateList[i].removeState();
				stateList[i]=null;
				return true;
			}
		}
		return false;
	}

	public State[] getStates()
	{
		int counter = 0;
		State[] a = new State[15];
		for (int i =0; i<15; i++) {
			if (stateList[i]!=null && stateList[i].getState()!="GodMode")
			{
				a[counter] = stateList[i];
				counter++;
			}
				}
		return a;
	}

	// Use this for initialization
	void Start () {
		for (int i =0; i<15; i++)
						stateList [i] = null;
	}

	// Update is called once per frame
	void Update () {
		for (int i =0; i<15; i++) {
			if (stateList[i]!=null)
			{
				if (stateList[i].apply()==false)
				{
					stateList[i]=null;
				}
			}
		}
	}
}
