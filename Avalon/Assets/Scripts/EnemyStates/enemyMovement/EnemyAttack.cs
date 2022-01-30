using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : BaseState
{
    private enemyStateMachine eSM;

    public EnemyAttack(enemyStateMachine stateMachine) : base("Enemy Attack", stateMachine)
    {
        eSM = (enemyStateMachine)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Attack");
        eSM.canAttack = true;
        eSM.isHit = false;
        
    }

    void attack()
    {
        //Debug.Log("Enemy Attacked");
        eSM.cooldown.doAttack();
        //eSM.cooldown.doCooldDown();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (Time.time > eSM.cooldown.cdTime)
        {
            eSM.cooldown.cdTime = Time.time + eSM.attackCooldown;
            attack();
        }
        else
        {
            eSM.cooldown.underCD = true;
        }
        if (eSM.cooldown.underCD && eSM.isHit)
        {
            eSM.enemyHit.doFlash();
        }
    }

    public override void Exit()
    {
        base.Exit();
        eSM.canAttack = false;
    }
}