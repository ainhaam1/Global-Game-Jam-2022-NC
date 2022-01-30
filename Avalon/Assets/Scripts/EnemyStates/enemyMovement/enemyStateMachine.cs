using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStateMachine : StateMachine
{
    [HideInInspector]
    public EnemyIdle enemyIdle;
    [HideInInspector]
    public EnemyFollow enemyFollow;
    [HideInInspector]
    public EnemyAttack enemyAttack;

    public Material flashMaterial;
    public float flashDuration;
    public Material orgMaterial;
    public GameObject hitCollider;
    public bool isInCooldown;
    public SpriteRenderer enemySprite;
    public enemyCooldown cooldown;
    public enemyIsHit enemyHit;
    public bool active;
    public float attackCooldown;
    public float attackTime;
    public Color enemyColor;
    public Transform player;
    public Transform raycastEnemyStart;
    public Transform raycastEnemyEnd;
    public bool canAttack;
    public float agroRange;
    public Rigidbody2D rb;
    public Animator anim;
    public float speed = 4f;
    public bool isHit;
    public bool white;

    private void Awake()
    {
        enemyIdle = new EnemyIdle(this);
        enemyFollow = new EnemyFollow(this);
        enemyAttack = new EnemyAttack(this);
    }

    protected override BaseState getInitialState()
    {
        return enemyIdle;
    }
}
