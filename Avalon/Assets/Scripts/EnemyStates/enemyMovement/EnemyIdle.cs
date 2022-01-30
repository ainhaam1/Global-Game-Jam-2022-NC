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
        eSM.isHit = false;
        base.Enter();
        if (!eSM.white)
        {
            eSM.enemySprite.color = Color.gray;
        }

    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (eSM.active)
        {
            stateMachine.changeState(eSM.enemyFollow);
        }
        if (eSM.health == 0)
        {
            eSM.cooldown.destroyEnemy();
        }
    }


}
