using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : BaseState
{
    private MovementSM mSM;
    private float _horizontalInput;
    private bool canAttack;
    public PlayerIdle(MovementSM stateMachine) : base("Player Idle", stateMachine) { mSM = (MovementSM)stateMachine; }

    public override void Enter()
    {
        base.Enter();
        _horizontalInput = 0f;
        canAttack = true;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        _horizontalInput = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(_horizontalInput) > Mathf.Epsilon)
        {
            stateMachine.changeState(((MovementSM) stateMachine).movingState);
        }

        if (Input.GetMouseButtonDown(0))
        {
            stateMachine.changeState(mSM.attackState);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.changeState(mSM.parryState);
        }
    }
}
