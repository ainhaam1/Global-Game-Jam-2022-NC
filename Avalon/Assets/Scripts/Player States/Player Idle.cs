using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : BaseState
{
    private float _horizontalInput;
    public PlayerIdle(MovementSM stateMachine) : base("Player Idle", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
        {
            stateMachine.changeState(((MovementSM) stateMachine).movingState);
        }
    }
}
