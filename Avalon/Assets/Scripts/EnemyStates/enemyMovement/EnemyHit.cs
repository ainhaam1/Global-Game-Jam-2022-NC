using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : BaseState
{
    private enemyStateMachine eSM;

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
        Debug.Log("knocked back");
        Vector2 newDir = new Vector2(1, 0);
        eSM.rb.AddForce(newDir * 3, ForceMode2D.Impulse);
        //other.gameObject.GetComponent<Rigidbody>().AddForce(player.transform.forward * 10, ForceMode.Impulse)
    }
}
