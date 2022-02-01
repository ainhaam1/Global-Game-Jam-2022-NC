using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public float attackRate = 0.2f;
    public int attackDamage = 40;
    public float knockbackPower = 200f;

    private float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(0))
            {
                animator.SetTrigger("Attack");
                Invoke("Attack", 0.33f);
                nextAttackTime = Time.time + 1f / attackRate;
            }
        } 
    }

    public void Attack()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        CinemachineShake.Instance.ShakeCamera(0.9f, .1f);
        foreach (Collider2D enemy in hitEnemies)
        {
            
            if (enemy.GetComponent<Enemy>())
            {
                enemy.GetComponent<Enemy>().takeDamage(attackDamage);
                enemy.GetComponent<Enemy>().takeKnockback(enemy.transform.parent.gameObject, -knockbackPower);
            } 
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
