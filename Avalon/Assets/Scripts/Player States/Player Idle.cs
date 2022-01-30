using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdle : BaseState
{
    private MovementSM mSM;
    private float _horizontalInput;
    public PlayerIdle(MovementSM stateMachine) : base("Player Idle", stateMachine) { mSM = (MovementSM)stateMachine; }

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

        if (Input.GetMouseButtonDown(0) && mSM.canAttack == true)
        {
            stateMachine.changeState(mSM.attackState);
            mSM.canAttack = false;
            mSM.pCooldown.StartCoroutine(mSM.pCooldown.Wait());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.changeState(mSM.parryState);
        }
    }
}
