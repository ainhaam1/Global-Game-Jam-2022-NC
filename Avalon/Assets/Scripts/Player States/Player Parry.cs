using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : BaseState
{
    private MovementSM mSM;

    public PlayerParry(MovementSM stateMachine) : base("Player Parry", stateMachine) { mSM = (MovementSM)stateMachine; }

    public override void Enter()
    {
        base.Enter();
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        mSM.speed = 0;
    }
}
