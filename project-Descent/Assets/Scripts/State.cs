using UnityEngine;
using System.Collections;

/*
Author: Mitchell Cook
Function: This class is the state interface which all states derive from.
Resources: NA
*/

//[System.Serializable]
public interface State 
{

	//applies the effect of the state, called at every Update
	bool apply();
		
	//Returns the name of the state
	string getState();

	//updates the state with another state
	void updateState(State state);

	void removeState();
}