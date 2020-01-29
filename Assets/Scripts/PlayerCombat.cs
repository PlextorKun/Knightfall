using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform hitbox;

    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 20;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Attack"))
        {
            Attack();
        }
    }

    void Attack() 
    {
        if (Input.GetButtonDown("Attack"))
        {
            animator.SetBool("IsAttacking", true);
        }
        else if (Input.GetButtonUp("Attack"))
        {
            animator.SetBool("IsAttacking", false);
        }

        Collider2D[] damagedEnemies = Physics2D.OverlapCircleAll(hitbox.position, attackRange, enemyLayers);

        foreach(Collider2D enemy in damagedEnemies)
        {
            enemy.GetComponent<EnemyHP>().takeDamage(attackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        if (hitbox == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(hitbox.position, attackRange);
    }
}
