using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    [SerializeField]Transform spawnPoint;
    private Animator animator;
    public float deathTime;
    bool damaged = false;
    bool attacking = false;


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("Hero")){
          animator = col.gameObject.GetComponent<Animator>();
            animator.SetBool("Damaged", true);
            StartCoroutine(kill(col));
        }



    }
    public IEnumerator kill(Collision2D col){
      yield return new WaitForSeconds(deathTime);
      col.transform.position = spawnPoint.position;
        damaged = false;
        animator.SetBool("Damaged", false);
      
    }
}
