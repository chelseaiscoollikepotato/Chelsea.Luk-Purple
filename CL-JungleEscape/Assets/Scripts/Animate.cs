using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    Animator Animator;

    Jump Jump;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
        Jump = GetComponent<Jump>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!Jump.isGrounded){
            Animator.SetBool("IsJumping", true);
            Animator.SetBool("IsIdle", false);
            Animator.SetBool("IsWalking", false);
            Animator.SetBool("IsWalkingBackwards", false);
        }

        if (Jump.isGrounded){
            Animator.SetBool("IsIdle", true);
            Animator.SetBool("IsJumping", false);
            Animator.SetBool("IsWalking", false);
            Animator.SetBool("IsWalkingBackwards", false);
            if (Input.GetAxisRaw("Vertical") == 1){
                Animator.SetBool("IsWalking", true);
                Animator.SetBool("IsIdle", false);
                Animator.SetBool("IsWalkingBackwards", false);
            }
            if(Input.GetAxisRaw("Vertical") == -1){
                Animator.SetBool("IsWalkingBackwards", true);
                Animator.SetBool("IsWalking", false);
                Animator.SetBool("IsIdle", false);
            }
        }
    }
}
