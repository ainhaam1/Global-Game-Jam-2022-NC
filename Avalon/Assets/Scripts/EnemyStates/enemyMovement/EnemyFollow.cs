using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : BaseState
{
    private enemyStateMachine eSM;
    private bool chasing;
    public EnemyFollow(enemyStateMachine stateMachine) : base("Enemy Follow", stateMachine)
    {
        eSM = (enemyStateMachine)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        eSM.rb.velocity =  new Vector2(eSM.speed, 0);
        chasing = true;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        float distToPlayer = Vector2.Distance(eSM.transform.position, eSM.playerRange.transform.position);
        if (distToPlayer > eSM.agroRange)
        {
            chasing = false;
            stateMachine.changeState(eSM.enemyIdle);
        }
        else
        {
            chasing = true;
        }

    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (chasing)
        {
            chasePlayer();
        }
    }

    private void chasePlayer()
    {
        eSM.transform.position = Vector2.MoveTowards(eSM.transform.position, new Vector2(eSM.playerRange.position.x - eSM.agroRange, 0) , eSM.speed);
    }
}
