using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : BaseState
{
    private enemyStateMachine eSM;
    public EnemyFollow(enemyStateMachine stateMachine) : base("Enemy Follow", stateMachine)
    {
        eSM = (enemyStateMachine)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        eSM.rb.velocity =  new Vector2(eSM.speed, 0);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        float distToPlayer = Vector2.Distance(eSM.transform.position, eSM.player.transform.position);
        Debug.Log(distToPlayer);
    }
}
