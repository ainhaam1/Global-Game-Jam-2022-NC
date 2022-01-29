using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementSM : StateMachine
{
    [HideInInspector]
    public PlayerIdle idleState;
    [HideInInspector]
    public PlayerMove movingState;
    [HideInInspector]
    public PlayerAttack attackState;
    public Rigidbody2D rb;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float speed = 4f;

    private void Awake()
    {
        idleState = new PlayerIdle(this);
        movingState = new PlayerMove(this);
        attackState = new PlayerAttack(this);
    }
    protected override BaseState getInitialState()
    {
        return idleState;
    }
}
