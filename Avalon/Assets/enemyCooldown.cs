using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyCooldown : MonoBehaviour
{

    public enemyStateMachine enemy;
    public bool underCD;
    public float cdTime;

    public void doAttack()
    {
        StartCoroutine(attack(enemy.attackTime));
    }
    public void doCooldDown()
    {

        underCD = true;

        StartCoroutine(coolDown(enemy.attackCooldown));
    }
    private IEnumerator attack(float time)
    {
        //Debug.Log("attack state turned red");
        //enemy.enemySprite.color = Color.red;
        enemy.anim.SetBool("canAttack", true);
        yield return new WaitForSeconds(time);
        enemy.anim.SetBool("canAttack", false);
        enemy.changeState(enemy.enemyFollow);
        //underCD = true;
        //doCooldDown();
    }
    
    private IEnumerator coolDown(float time)
    {
        //enemy.enemySprite.color = Color.blue;
        
        yield return new WaitForSeconds(time);
        
        enemy.canAttack = false;
        if (enemy.isHit)
        {
            Debug.Log("cooldown hit");
        }
        enemy.changeState(enemy.enemyFollow);
    }

    public IEnumerator flashHit()
    {
        enemy.isHit = true;
        enemy.enemySprite.material = enemy.flashMaterial;
        Debug.Log("Change Material");
        yield return new WaitForSeconds(enemy.flashDuration);
        enemy.enemySprite.material = enemy.orgMaterial;
        enemy.isHit = false;
    }
}
