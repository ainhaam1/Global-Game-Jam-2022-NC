using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : BaseState
{
    private MovementSM mSM;

    public PlayerHit(MovementSM stateMachine) : base("Player Hit", stateMachine)
    {
        mSM = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("entered hit state");
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (!mSM.isHit)
        {
            stateMachine.changeState(mSM.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        mSM.rb.AddForce(new Vector2(-1, 0) * 3, ForceMode2D.Impulse);
        if (mSM.pHealth.currentEnemy == "DarkEnemy" || mSM.pHealth.currentEnemy == "DarkEnemy" || mSM.pHealth.currentEnemy == "Enemy")
        {
            Debug.Log("took 20 damage");
            mSM.pHealth.takeDamage(20);
            mSM.isHit = false;
        } else
        {
            Debug.Log("took 40 damage");
            mSM.pHealth.takeDamage(40);
            mSM.isHit = false;
        }
    }
}
