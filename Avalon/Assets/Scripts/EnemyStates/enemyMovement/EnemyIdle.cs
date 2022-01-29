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
        eSM.rb.velocity = new Vector2(0,0);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }
}
