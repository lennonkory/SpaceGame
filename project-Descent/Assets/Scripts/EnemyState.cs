using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: The abstract template for enemy states.
*/

public abstract class EnemyState {

	//for normal enemies
	public abstract void Execute(EnemyAI enemyunit);

	//just for boss enemy
	public abstract void ExecuteBoss(EnemyBossAI enemyunit);

}
