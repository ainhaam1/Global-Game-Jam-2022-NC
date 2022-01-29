using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public PlayerIdle idleState;
    [HideInInspector]
    public PlayerMove movingState;
    public Rigidbody2D rb;
    public float speed = 4f;

    private void Awake()
    {
        idleState = new PlayerIdle(this);
        movingState = new PlayerMove(this);
    }
    protected override BaseState getInitialState()
    {
        return idleState;
    }
}
