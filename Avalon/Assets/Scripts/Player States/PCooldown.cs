using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCooldown : MonoBehaviour
{
    public MovementSM mSM;
    // Start is called before the first frame update
    public IEnumerator Wait()
    {
        Debug.Log("cooldown");
        yield return new WaitForSeconds(2f);
        mSM.canAttack = true;
    }
}
