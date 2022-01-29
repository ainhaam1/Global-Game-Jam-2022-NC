using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCooldown : MonoBehaviour
{

    public enemyStateMachine enemy;

    public void Awake()
    {
        Debug.Log("Waiting");
        StartCoroutine(attack(enemy.attackTime));
    }
    private IEnumerator attack(float time)
    {
        enemy.enemySprite.color = Color.red;
        yield return new WaitForSeconds(time);
        StartCoroutine(coolDown(enemy.attackCooldown));
    }
    
    private IEnumerator coolDown(float time)
    {
        enemy.enemySprite.color = Color.blue;
        yield return new WaitForSeconds(time);
        enemy.canAttack = false;
        enemy.changeState(enemy.enemyFollow);
    }
}
