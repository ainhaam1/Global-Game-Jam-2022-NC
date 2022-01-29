using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : BaseState
{
    private MovementSM mSM;
    private float _horizontalInput;
    private Vector3 m_Velocity = Vector3.zero;
    [Range(0, .3f)] [SerializeField] private float MovementSmoothing = .01f;	// How much to smooth out the movement

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
        _horizontalInput = Input.GetAxisRaw("Horizontal") * mSM.speed;
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        {
            mSM.rb.velocity = new Vector2(0, 0);
            stateMachine.changeState(((MovementSM)stateMachine).idleState);
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        Vector3 targetVelocity = new Vector2((_horizontalInput * Time.fixedDeltaTime) * 10f, mSM.rb.velocity.y);
        mSM.rb.velocity = Vector3.SmoothDamp(mSM.rb.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);
    }
}

