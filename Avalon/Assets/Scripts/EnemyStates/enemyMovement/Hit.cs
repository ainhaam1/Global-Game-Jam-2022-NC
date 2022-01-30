using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public MovementSM mSM;
    public enemyStateMachine eSM;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AttackPoint")
        {
            if (mSM.returnState().Equals("Player Attack"))
            {
                Debug.Log("hit true");
                eSM.isHit = true;
            }
        }
    }
}
