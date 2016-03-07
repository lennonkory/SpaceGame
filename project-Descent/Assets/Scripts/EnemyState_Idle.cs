using UnityEngine;
using System.Collections;

/*
Author: Chris Landon
Function: No functions occur when enemy is idle.
*/

public class EnemyState_Idle : EnemyState {

	public override void Execute(EnemyAI enemyunit){
		//Enemy sits in place
	}

	public override void ExecuteBoss(EnemyBossAI enemyunit){
		//Boss sits in place
	}
}
