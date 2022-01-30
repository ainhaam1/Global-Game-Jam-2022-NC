using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCooldown : MonoBehaviour
{
    public MovementSM mSM;
    // Start is called before the first frame update
    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        mSM.canAttack = true;
    }

    public IEnumerator WaitForAnim()
    {
        yield return new WaitForSeconds(0.55f);
        mSM.animator.SetBool("Attack", false);
    }
}
