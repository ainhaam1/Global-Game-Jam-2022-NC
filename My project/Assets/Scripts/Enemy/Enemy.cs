using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public int maxHealth = 100;

    private bool isAttacking;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking)
        {

        }
    }
    public void takeDamage(int damage)
    {
        FindObjectOfType<HitStop>().Stop(0.1f);
        currentHealth -= damage;
        animator.SetTrigger("Hurt");
        if (currentHealth <= 0)
        {
            Die();
        }
        
    }

    public void takeKnockback(GameObject obj, float power)
    {
        Vector2 dir = obj.transform.position - transform.position;
        obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(- dir.x * power, 0),ForceMode2D.Impulse);
    }

    void Die()
    {
        Debug.Log("enemy died!");
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Attack", true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            animator.SetBool("Attack", false);
        }
    }
}
