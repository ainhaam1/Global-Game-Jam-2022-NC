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
    [HideInInspector]
    public PlayerHit hitState;


    public PCooldown pCooldown;
    public PlayerHealth pHealth;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public enemyStateMachine eSM;
    public float speed = 4f;
    public bool isHit;
    public bool canAttack = true;
    public bool whiteSword;
    public Transform respawnPos;

    private void Awake()
    {
        idleState = new PlayerIdle(this);
        movingState = new PlayerMove(this);
        attackState = new PlayerAttack(this);
        parryState = new PlayerParry(this);
        hitState = new PlayerHit(this);
        canAttack = true;
    }
    protected override BaseState getInitialState()
    {
        return idleState;
    }
}
