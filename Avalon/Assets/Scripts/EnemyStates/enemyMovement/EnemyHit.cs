using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : BaseState
{
    private enemyStateMachine eSM;
    public bool canHit;

    public EnemyHit(enemyStateMachine stateMachine) : base("Enemy Hit", stateMachine)
    {
        eSM = (enemyStateMachine)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        eSM.isHit = true;
        knockBack();
        eSM.isHit = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (!eSM.isHit)
        {
            eSM.changeState(eSM.enemyFollow);
        }
    }

    void knockBack()
    {
        eSM.hit.StartCoroutine(eSM.hit.WaitForHit());
        if (canHit)
        {
            Debug.Log("force here");
            Vector2 newDir = new Vector2(1, 0);
            eSM.rb.AddForce(newDir * 3, ForceMode2D.Impulse);
        }
        canHit = false;
    }
}
