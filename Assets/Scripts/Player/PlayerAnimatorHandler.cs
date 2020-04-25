using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using btnNames = Dictionary.InputButtonNames;

public class PlayerAnimatorHandler : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void playMeleeAttack()
    { 
        animator.Play("Attack");
        animator.SetBool("OnGround", true);
    }

    public void playGetHit()
    {
        animator.Play("GetHit");
        animator.SetBool("OnGround", true);
    }


    void Update()
    {
        if(!CrossPlatformInputManager.GetButtonDown(btnNames.ATTACK))
        {
            animator.SetBool("Attack", false);
        }
    }
}
