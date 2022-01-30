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
                eSM.isHit = true;
        }
    }

    public IEnumerator WaitForHit()
    {
        yield return new WaitForSeconds(0.3f);
        eSM.enemyHit.canHit = true;
    }
}
