using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : BaseState
{
    private MovementSM mSM;
    public bool isAttacking;
    private float attackRange = 1f;

    public PlayerAttack(MovementSM stateMachine) : base("Player Attack", stateMachine)
    {
        mSM = (MovementSM)stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        isAttacking = true;
        mSM.animator.SetBool("Attack", true);
    }

    public override void Exit()
    {
        mSM.pCooldown.StartCoroutine(mSM.pCooldown.WaitForAnim());
        base.Exit();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (!isAttacking)
        {
            stateMachine.changeState(mSM.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        //Detech enemies withini range
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(mSM.attackPoint.position, attackRange, mSM.enemyLayers);
        //apply damage
        foreach(Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
        }
        isAttacking = false;
    }
}
