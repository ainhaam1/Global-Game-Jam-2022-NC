using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : BaseState
{
    private MovementSM mSM;
    private float _horizontalInput;

    public PlayerMove(MovementSM stateMachine) : base("Player Move", stateMachine)
    {
        mSM = (MovementSM)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        {
            stateMachine.changeState(((MovementSM)stateMachine).idleState);
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector2 vel = mSM.rb.velocity;
        vel.x = _horizontalInput * mSM.speed;
        mSM.rb.velocity = vel;
    }
}

