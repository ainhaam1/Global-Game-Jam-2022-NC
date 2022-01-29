using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdle : BaseState
{
    private enemyMovementSM eMSM;
    public EnemyIdle(enemyMovementSM stateMachine) : base("Enemy Idle", stateMachine)
    {
        eMSM = (enemyMovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();

    }
}
