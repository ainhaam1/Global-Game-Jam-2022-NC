using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : BaseState
{
    private MovementSM mSM;
    public bool isAttacking;
    public float attackRange = 1f;

    public PlayerAttack(MovementSM stateMachine) : base("Player Attack", stateMachine)
    {
        mSM = (MovementSM)stateMachine;
    }
    public override void Enter()
    {
        base.Enter();
        isAttacking = true;
        mSM.animator.SetBool("Attack", true);
        mSM.attackPoint.GetComponent<BoxCollider2D>().enabled = true;
    }

    public override void Exit()
    {
        mSM.pCooldown.StartCoroutine(mSM.pCooldown.WaitForAnim());
        base.Exit();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (mSM.isHit)
        {
            isAttacking = false;
            stateMachine.changeState(mSM.hitState);
        }

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
            mSM.eSM = enemy.GetComponent<enemyStateMachine>();
            //enemy.GetComponent<enemyStateMachine>().isHit = true;
            
        }
        isAttacking = false;
    }

    
}
