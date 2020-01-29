using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public Animator anim;

    public int maxHealth = 100;
    int currentHealth = 100;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        anim.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Debug.Log("Enemy died!");

        anim.SetBool("IsDead", true);

        this.gameObject.layer = 11;
        //GetComponent<Collider2D>().enabled = false;
        //GetComponent<CircleCollider2D>().enabled = false;
        this.enabled = false;
    }
}
