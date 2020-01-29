using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMovement = 0f;

    bool jump = true;
    bool crouch = false;
    bool attack = false;

    void Update () {
        horizontalMovement = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMovement));
        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
        
        if (Input.GetButtonDown("Crouch")) {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch")) {
            crouch = false;
        }

        if (Input.GetButtonDown("Attack")) {
            attack = true;
            animator.SetBool("IsAttacking", true);
        } else if (Input.GetButtonUp("Attack")) {
            attack = false;
            animator.SetBool("IsAttacking", false);
        }
    }

    public void OnLanding () {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate () {

        controller.Move(horizontalMovement * Time.fixedDeltaTime, crouch, jump);
        jump = false;

    }
}
