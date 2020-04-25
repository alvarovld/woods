using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tag = Dictionary.Tags;

public class MeleeAttackHandler : MonoBehaviour
{
    public float hitStrength;
    GameObject currentTarget;
    public string targetTag;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.Equals(targetTag))
        {
            currentTarget = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag.Equals(targetTag))
        {
            currentTarget = null;
        }
    }

    bool isAttackingTarget()
    {
        return currentTarget != null;
    }

    public void attack()
    {
        Manager.attack(gameObject);
    }


    public void sendHitToTarget()
    {
        if(!isAttackingTarget())
        {
            return;
        }
        Manager.sendHit(currentTarget, hitStrength);
        Debug.Log("[MeleeAttackHandler] GameObject: "+ gameObject.name+" sent attack to target: " + currentTarget);
    }


    // Manager class to handle either enemy or player actions

    private class Manager
    {
        public static void sendHit(GameObject other, float health)
        {
            switch (other.tag)
            {
                case Tag.ENEMY:
                    enemyGetHit(other, health);
                    break;
                case Tag.PLAYER:
                    playerGetHit(other, health);
                    break;
                default:
                    Debug.LogError("[HitHandlerManager] Tag not found: " + other.tag);
                    break;

            }
        }

        static void enemyGetHit(GameObject other, float health)
        {
            other.GetComponent<EnemyStats>().reduceHealth(health);
            other.GetComponent<EnemyAnimatorHandler>().playGetHit();
        }

        static void playerGetHit(GameObject other, float health)
        {
            PlayerStats.reduceHealth(health);
            other.GetComponent<PlayerAnimatorHandler>().playGetHit();
        }
        public static void attack(GameObject obj)
        {
            if (obj.GetComponent<EnemyAnimatorHandler>() != null)
            {
                obj.GetComponent<EnemyAnimatorHandler>().playMeleeAttack();
                return;
            }
            else if (obj.GetComponent<PlayerAnimatorHandler>() != null)
            {
                obj.GetComponent<PlayerAnimatorHandler>().playMeleeAttack();
                return;
            }
            Debug.LogError("[MeleeAttackHandler] No Animator handler found for GameObject: " + obj.name);
        }
    }
}

