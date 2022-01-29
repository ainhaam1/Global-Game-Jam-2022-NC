using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerParry : BaseState
{
    [HideInInspector]
    public MovementSM mSM;

    private Parry parry;
    private bool isParrying;
    private float timer = 0;
    private float seconds;
    public PlayerParry(MovementSM stateMachine) : base("Player Parry", stateMachine) { mSM = (MovementSM)stateMachine; }

    public override void Enter()
    {
        base.Enter();
        parry = GameObject.FindGameObjectWithTag("Player").GetComponent<Parry>();
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
        timer += Time.fixedDeltaTime;
        seconds = timer % 60;
        Vector3 oldV = mSM.rb.velocity;
        mSM.rb.velocity = Vector3.zero;
        mSM.rb.constraints = RigidbodyConstraints2D.FreezeAll;


        if (parry.parrySuccess == true)
        {
            seconds = 0;
            timer = 0;
            Debug.Log("parry succesful");
            mSM.rb.constraints = RigidbodyConstraints2D.None;
            mSM.rb.velocity = oldV;
            isParrying = false;
        }

        else if (seconds >= 5)
        {
            seconds = 0;
            timer = 0;
            mSM.rb.constraints = RigidbodyConstraints2D.None;
            mSM.rb.velocity = oldV;
            isParrying = false;
        }
    }


}
