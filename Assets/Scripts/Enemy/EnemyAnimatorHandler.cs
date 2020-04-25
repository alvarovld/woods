using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using behaviourCase = EnemyBehaviourHandler.BehaviourEnum;
public class EnemyAnimatorHandler : MonoBehaviour
{
    PlayerSituationAwareness situation;
    behaviourCase behaviour;

    Animator animator;

    private void Start()
    {
        situation = GetComponent<PlayerSituationAwareness>();
        animator = GetComponent<Animator>();
    }

    public void playGetHit()
    {
        animator.Play("GetHit");
        animator.SetBool("KeepGuardStand", true);
    }

    public void playMeleeAttack()
    {
        animator.Play("Attack");
        animator.SetBool("OnGround", true);
    }

    public void updateAnimator(behaviourCase behaviour)
    {
        this.behaviour = behaviour;
    }

    void updateParameters()
    {
        animator.SetBool("Run", false);
        animator.SetBool("Walk", false);
        animator.SetBool("KeepGuardLeft", false);
        animator.SetBool("KeepGuardRight", false);
        animator.SetBool("RunBackwards", false);

        switch (behaviour)
        {
            case behaviourCase.Attack:
                animator.SetBool("Run", true);
                animator.SetBool("Walk", false);
                animator.SetBool("KeepGuardLeft", false);
                animator.SetBool("KeepGuardRight", false);
                animator.SetBool("RunBackwards", false);
                break;
            case behaviourCase.RunBackwards:
                animator.SetBool("RunBackwards", true);
                animator.SetBool("Run", false);
                animator.SetBool("Walk", false);
                animator.SetBool("KeepGuardLeft", false);
                animator.SetBool("KeepGuardRight", false);
                break;
            case behaviourCase.KeepGuardLeft:
                animator.SetBool("KeepGuardLeft", true);
                animator.SetBool("Run", false);
                animator.SetBool("Walk", false);
                animator.SetBool("KeepGuardRight", false);
                animator.SetBool("RunBackwards", false);
                break;
            case behaviourCase.KeepGuardRight:
                animator.SetBool("KeepGuardRight", true);
                animator.SetBool("Run", false);
                animator.SetBool("Walk", false);
                animator.SetBool("KeepGuardLeft", false);
                animator.SetBool("RunBackwards", false);
                break;
            case behaviourCase.KeepGuardStand:
                animator.SetBool("KeepGuardStand", true);
                animator.SetBool("Run", false);
                animator.SetBool("Walk", false);
                animator.SetBool("KeepGuardLeft", false);
                animator.SetBool("KeepGuardRight", false);
                animator.SetBool("RunBackwards", false);
                break;
        }
    }

    private void FixedUpdate()
    {
        if (!situation.isEnemyAwayeOfPlayer())
        {
            animator.SetBool("Idle", true);
            animator.SetBool("KeepGuardStand", false);
        }
        else
        {
            animator.SetBool("Idle", false);
            animator.SetBool("KeepGuardStand", true);
        }

        updateParameters();
    }



}
