using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [HideInInspector]
    public string currentEnemy;

    private float maxHealth = 160f;
    private float currentHealth;
    private int currentIndex;
    private int currentDamage;
    public MovementSM mSM;
    public Sprite[] healthBars;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        currentIndex = 0;
        healthBar.sprite = healthBars[currentIndex];
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            mSM.transform.position = mSM.respawnPos.position;
        }
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        currentDamage += damage;

        if (currentDamage >= 20 && currentDamage < 40)
        {
            currentIndex += 1;
            currentDamage = 0;
        } else if (currentDamage >= 40)
        {
            currentIndex += 2;
            currentDamage = 0;
        }
        healthBar.sprite = healthBars[currentIndex];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        currentEnemy = collision.gameObject.tag;
        if (collision.gameObject.CompareTag("EnemyAttack"))
        {
            Debug.Log("hit");
            
            if (collision.gameObject.GetComponentInParent<enemyStateMachine>().canAttack == true)
            {
                Debug.Log("hit by enemy");
                Debug.Log("took 20 damage");
                mSM.isHit = true;
               
            }
        }
    }
}
