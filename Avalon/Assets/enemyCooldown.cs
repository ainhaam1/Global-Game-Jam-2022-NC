using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCooldown : MonoBehaviour
{

    public enemyStateMachine enemy;

    public void Awake()
    {
        StartCoroutine(attack(enemy.attackTime));
    }
    private IEnumerator attack(float time)
    {
        //Debug.Log("attack state turned red");
        enemy.enemySprite.color = Color.red;
        yield return new WaitForSeconds(time);
        StartCoroutine(coolDown(enemy.attackCooldown));
    }
    
    private IEnumerator coolDown(float time)
    {
        enemy.enemySprite.color = Color.blue;
        yield return new WaitForSeconds(time);
        enemy.canAttack = false;
        if (enemy.isHit)
        {
            enemy.changeState(enemy.enemyHit);
        }
        enemy.changeState(enemy.enemyFollow);
    }
}
