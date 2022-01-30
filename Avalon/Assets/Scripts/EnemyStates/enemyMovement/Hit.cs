using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public MovementSM mSM;
    public enemyStateMachine eSM;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //if (mSM.isAttacking)
            //{
            //    eSM.isHit = true;
            //}
        }
    }
}
