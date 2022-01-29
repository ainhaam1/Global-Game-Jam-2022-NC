using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovementSM : StateMachine
{
    [HideInInspector]
    public EnemyIdle enemyIdle;
    public Rigidbody2D rb;
    public float speed = 4f;

    private void Awake()
    {
        enemyIdle = new EnemyIdle(this);
    }

    protected override BaseState getInitialState()
    {
        return enemyIdle;
    }
}
