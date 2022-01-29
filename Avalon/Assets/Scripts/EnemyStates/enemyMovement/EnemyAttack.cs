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
        Debug.Log("Attack");
        eSM.canAttack = true;
        attack();
    }
    void coolDown()
    {
        //Wait 3 seconds then go to the attack state
        eSM.cooldown.Awake();
    }
    void attack()
    {
        //Debug.Log("Enemy Attacked");
        eSM.enemySprite.color = Color.red;
        coolDown();
    }

    public override void Exit()
    {
        base.Exit();
        eSM.canAttack = false;
    }
}
