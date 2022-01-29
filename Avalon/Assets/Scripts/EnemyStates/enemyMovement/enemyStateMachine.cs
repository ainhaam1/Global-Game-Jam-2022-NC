using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyStateMachine : StateMachine
{
    [HideInInspector]
    public EnemyIdle enemyIdle;
    [HideInInspector]
    public EnemyFollow enemyFollow;
    public Transform player;
    public Transform raycastEnemy;
    public bool sawPlayer;
    public float agroRange;
    public Rigidbody2D rb;
    public float speed = 4f;

    private void Awake()
    {
        enemyIdle = new EnemyIdle(this);
        enemyFollow = new EnemyFollow(this);
    }

    protected override BaseState getInitialState()
    {
        return enemyIdle;
    }
}
