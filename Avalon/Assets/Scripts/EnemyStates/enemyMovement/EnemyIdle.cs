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
        float distToPlayer = Vector2.Distance(eSM.transform.position, eSM.playerRange.transform.position);
        if (distToPlayer < eSM.agroRange)
        {
            stateMachine.changeState(eSM.enemyFollow);
        }
        //Debug.Log(distToPlayer);
    }
}
