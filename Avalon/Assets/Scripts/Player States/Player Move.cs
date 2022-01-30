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
        if (mSM.isHit)
        {
            stateMachine.changeState(mSM.hitState);
        }
        if (Mathf.Abs(_horizontalInput) < Mathf.Epsilon)
        {
            mSM.rb.velocity = new Vector2(0, 0);
            mSM.animator.SetFloat("Speed", 0);
            stateMachine.changeState(mSM.idleState);
        }
        
        if (Input.GetMouseButtonDown(0) && mSM.canAttack == true)
        {
            mSM.animator.SetFloat("Speed", 0);
            stateMachine.changeState(mSM.attackState);
            mSM.canAttack = false;
            mSM.pCooldown.StartCoroutine(mSM.pCooldown.Wait());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mSM.animator.SetFloat("Speed", 0);
            stateMachine.changeState(mSM.parryState);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            mSM.animator.SetBool("White", true);
            mSM.whiteSword = true;
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            mSM.animator.SetBool("White", false);
            mSM.whiteSword = false;
        }
    }
    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (_horizontalInput < 0)
        {
            mSM.animator.SetFloat("Speed", 1);
            Vector3 targetVelocityS = new Vector2((_horizontalInput * Time.fixedDeltaTime) * 3f, mSM.rb.velocity.y);
            mSM.rb.velocity = Vector3.SmoothDamp(mSM.rb.velocity, targetVelocityS, ref m_Velocity, MovementSmoothing);
        }
        else
        {
            mSM.animator.SetFloat("Speed", 1);
            Vector3 targetVelocity = new Vector2((_horizontalInput * Time.fixedDeltaTime) * 7f, mSM.rb.velocity.y);
            mSM.rb.velocity = Vector3.SmoothDamp(mSM.rb.velocity, targetVelocity, ref m_Velocity, MovementSmoothing);
        }
    }
}

