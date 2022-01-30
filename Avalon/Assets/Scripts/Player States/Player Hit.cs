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
        

        
        mSM.pHealth.takeDamage(20);
        mSM.isHit = false;
    }
}
