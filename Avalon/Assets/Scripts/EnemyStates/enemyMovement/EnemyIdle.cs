using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : BaseState
{
    private enemyStateMachine eSM;
    
    public EnemyIdle(enemyStateMachine stateMachine) : base("Enemy Idle", stateMachine)
    {
        eSM = (enemyStateMachine)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        if (eSM.active)
        {
            stateMachine.changeState(eSM.enemyFollow);
        }
        
    }

   
}
