using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : BaseState
{
    private enemyStateMachine eSM;
    public bool canHit = false;

    public EnemyHit(enemyStateMachine stateMachine) : base("Enemy Hit", stateMachine)
    {
        eSM = (enemyStateMachine)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enemy Hit");
        eSM.isHit = true;
        flash();
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

    void flash()
    {
        eSM.cooldown.flashHit();
    }

    //void knockBack()
    //{
    //    eSM.hit.StartCoroutine(eSM.hit.WaitForHit());
    //    Debug.Log("force here");
    //    //canHit = true;
    //    if (canHit)
    //    {
    //        Debug.Log("in force");

    //        Vector2 newDir = new Vector2(1, 0);
    //        Color oldC = eSM.enemyColor; 
    //        eSM.enemyColor = new Color(255, 255, 255);
    //        eSM.rb.AddForce(newDir * 3, ForceMode2D.Impulse);
    //        eSM.enemyColor = oldC;
    //        canHit = false;
    //    }
    //}
}
