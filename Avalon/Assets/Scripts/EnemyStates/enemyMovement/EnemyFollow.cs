using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : BaseState
{
    private enemyStateMachine eSM;
    private bool tooFarToPlayer;
    private bool tooCloseToPlayer;
    public EnemyFollow(enemyStateMachine stateMachine) : base("Enemy Follow", stateMachine)
    {
        eSM = (enemyStateMachine)stateMachine;
    }

    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Follow");
        eSM.enemySprite.color = eSM.enemyColor;
        eSM.canAttack = false;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        //Get in the range
        if (!tooFar(eSM.agroRange / 4))
        {
            tooFarToPlayer = true;
        }
        else if (tooClose(eSM.agroRange / 4))
        {
            tooCloseToPlayer = true;
        }
        //if not too close and not too far and player cant attack yet
        if (!tooCloseToPlayer && !tooFarToPlayer)
        {
            stateMachine.changeState(eSM.enemyAttack);
        }
        if (eSM.isHit)
        {
            tooFarToPlayer = true;
            stateMachine.changeState(eSM.enemyHit);
        }
    }

    public override void UpdatePhysics()
    {
        base.UpdatePhysics();
        if (tooFarToPlayer)
        {
            getInAttackRange();
        }
        else if (tooCloseToPlayer)
        {
            backUp();
        }
    }
    bool tooFar(float dist)
    {
        bool val = false;
        var castDist = dist;

        Vector2 endPos = eSM.raycastEnemyStart.position + Vector3.left * dist;

        RaycastHit2D hit = Physics2D.Linecast(eSM.raycastEnemyStart.position, endPos, 1 << LayerMask.NameToLayer("Default"));
        if (hit.collider != null)
        {
            val = true;
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                tooFarToPlayer = false;
                //Debug.Log("Enemy is in attack range");
            }
        }
        Debug.DrawLine(eSM.raycastEnemyStart.position, endPos, Color.red);

        return val;
    }

    bool tooClose(float dist)
    {
        bool val = false;
        var castDist = dist;

        Vector2 endPos = eSM.raycastEnemyEnd.position + Vector3.left * dist;

        RaycastHit2D hit = Physics2D.Linecast(eSM.raycastEnemyEnd.position + new Vector3(eSM.agroRange, 0), endPos, 1 << LayerMask.NameToLayer("Default"));
        if (hit.collider != null)
        {
            val = true;
            if (hit.collider.gameObject.CompareTag("Player"))
            {
                tooCloseToPlayer = true;
                //Debug.Log("Enemy is Too Close");
            }
        }
        //Debug.DrawLine(eSM.raycastEnemyEnd.position, endPos, Color.blue);

        return val;
    }

    void getInAttackRange()
    {
        eSM.transform.Translate(Vector3.left * eSM.speed * Time.fixedDeltaTime);
    }

    void backUp()
    {
        eSM.transform.Translate(Vector3.right * eSM.speed * Time.fixedDeltaTime / 2);
    }

}
