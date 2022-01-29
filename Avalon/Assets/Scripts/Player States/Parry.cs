using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parry : MonoBehaviour
{
    [HideInInspector]
    public bool parrySuccess;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            parrySuccess = true;
            //Deal damage to enemy
        }
    }

    public IEnumerator Wait()
    {
        yield return new WaitForSeconds(1);
    }
}
