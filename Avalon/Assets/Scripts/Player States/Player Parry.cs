using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : BaseState
{
    private MovementSM mSM;
    private Parry parry;
    private bool isParrying;
    public PlayerParry(MovementSM stateMachine) : base("Player Parry", stateMachine) { mSM = (MovementSM)stateMachine; }

    public override void Enter()
    {
        base.Enter();
        parry = new Parry();
        isParrying = true;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        if (!isParrying)
        {
            stateMachine.changeState(mSM.idleState);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        mSM.speed = 0;

        if (parry.parrySuccess == true)
        {
            //play animation
        }
        isParrying = false;
    }


}
