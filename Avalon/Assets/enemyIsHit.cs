using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyIsHit : MonoBehaviour
{
    public enemyStateMachine enemy;
    public bool changed;

    public void doFlash()
    {
        StartCoroutine(flashHit());
    }
    private IEnumerator flashHit()
    {
        yield return new WaitForSeconds(0.3f);
        if (!changed)
        {
            enemy.enemySprite.material = enemy.flashMaterial;
            Debug.Log("Change Material");
            changed = true;
        }
        yield return new WaitForSeconds(enemy.flashDuration);
        enemy.enemySprite.material = enemy.orgMaterial;
        enemy.isHit = false;
    }
}
