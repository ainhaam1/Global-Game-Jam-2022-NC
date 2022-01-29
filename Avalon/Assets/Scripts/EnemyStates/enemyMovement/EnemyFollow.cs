using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : BaseState
{
    private enemyStateMachine eSM;
    public EnemyFollow(enemyStateMachine stateMachine) : base("Enemy Follow", stateMachine)
    {
        eSM = (enemyStateMachine)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        canSeePlayer(eSM.agroRange);
    }

    bool canSeePlayer(float dist)
    {
        bool val = false;
        var castDist = dist;

        Vector2 endPos = eSM.raycastEnemy.position + Vector3.left * dist;

        RaycastHit2D hit = Physics2D.Linecast(eSM.raycastEnemy.position, endPos, 1 << LayerMask.NameToLayer("Default"));
        if (hit.collider != null)
        {
            val = true;
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                Debug.Log("Hit Player");
            }
        }
        Debug.DrawLine(eSM.raycastEnemy.position, endPos, Color.red);

        return val;
    }
}
