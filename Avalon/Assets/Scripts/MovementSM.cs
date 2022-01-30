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
    [HideInInspector]
    public PlayerParry parryState;

    public PCooldown pCooldown;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float speed = 4f;
    public bool canAttack;

    private void Awake()
    {
        idleState = new PlayerIdle(this);
        movingState = new PlayerMove(this);
        attackState = new PlayerAttack(this);
        parryState = new PlayerParry(this);
    }
    protected override BaseState getInitialState()
    {
        return idleState;
    }
}
