using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBehaviourHandler : MonoBehaviour
{
    BehaviourEnum behaviour;
    public GameObject player;
    public float dangerDistance;
    public float performAttackDistance;
    public float stopAttackingDistance;
    public float distanceToResetBehaviour;
    IActionBehaviour action;
    public float runBackwardsDistance;
    PlayerSituationAwareness playerSituationAwareness;

    public enum BehaviourEnum
    {
        Unknown = 0,
        Attack = 1,
        RunBackwards = 2,
        GetCrazy = 3,
        KeepGuardStand = 4,
        KeepGuardRight = 5,
        KeepGuardLeft = 6,
        WalkFree = 7,
        Idle = 8,
        PerformAttack = 9
    }


    private void Start()
    {
        playerSituationAwareness = GetComponent<PlayerSituationAwareness>();
        setBehaviour();
        setBehaviourFinishCallBack();
    }

    private void Update()
    {
        if (action.isProccessingAction())
        {
            return;
        }

        setBehaviour();
        setBehaviourFinishCallBack();
    }

    float distanceToPlayer()
    {
        return (player.transform.position - transform.position).magnitude;
    }

    BehaviourEnum getRandomDefaultBehaviour()
    {
        return (BehaviourEnum)Random.Range(4, 7);
    }

    bool attackCondition()
    {
        return distanceToPlayer() <= performAttackDistance || 
               !playerSituationAwareness.isEnemyAwayeOfPlayer() || 
               distanceToPlayer() >= stopAttackingDistance;
    }


    void setBehaviourFinishCallBack()
    {
        switch (behaviour)
        {
            case BehaviourEnum.Attack:
                action = GetComponent<ActionSetByCondition>();
                action.setProcessingUntilConditionApplies(attackCondition);
                break;
            case BehaviourEnum.RunBackwards:
                action = GetComponent<ActionSetByCondition>();
                action.setProcessingUntilConditionApplies(() => { return distanceToPlayer() > runBackwardsDistance; });
                break;
            case BehaviourEnum.KeepGuardLeft:
                action = GetComponent<ActionSetByTime>();
                action.setProcessingUntilConditionApplies(0.5f, 0.5f);
                break;
            case BehaviourEnum.KeepGuardRight:
                action = GetComponent<ActionSetByTime>();
                action.setProcessingUntilConditionApplies(0.5f, 0.5f);
                break;
            case BehaviourEnum.KeepGuardStand:
                action = GetComponent<ActionSetByTime>();
                action.setProcessingUntilConditionApplies(1.5f, 2.5f);
                break;
            case BehaviourEnum.PerformAttack:
                action = GetComponent<ActionSetByTime>();
                action.setProcessingUntilConditionApplies(1, 2);
                break;
            default:
                action = GetComponent<ActionSetByTime>();
                action.setProcessingUntilConditionApplies(1f, 1f);
                Debug.LogWarning("[Behaviour] No action set, setting stand still");
                return;
        }
    }

    bool isCloseEnoughToRunAndAttackPlayer()
    {
        return distanceToPlayer() <= dangerDistance;
    }

    bool setMandatoryBehaviourCase()
    {
        behaviour = BehaviourEnum.PerformAttack;
        return true;

        if (!playerSituationAwareness.isEnemyAwayeOfPlayer())
        {
            //Debug.Log("[EnemyBehaviour] Enemy not aware of player, walking free");
            behaviour = BehaviourEnum.Idle;
            return true;
        }
        /*else if (isCloseEnoughToRunAndAttackPlayer())
        {
            Debug.Log("[Behaviour] Player too close, attacking him");
            behaviour = BehaviourEnum.Attack;
            return true;
        }*/
        return false;
    }

    void setBehaviour()
    { 

        if(setMandatoryBehaviourCase())
        {
            return;
        }

        BehaviourEnum nonDefBehaviour = getRandomNonDefaultBehaviour();
        BehaviourEnum defBehaviour = getRandomDefaultBehaviour();

        if (Random.Range(0f, 2f) <= 1.2f)
        {
            behaviour = defBehaviour;
        }
        else
        {
            behaviour = nonDefBehaviour;
        }

        Debug.Log("[EnemyBehaviour] Behaviour: " + behaviour);
    }

    public BehaviourEnum getBehaviour()
    {
        return behaviour;
    }

    // TODO: implement the rest of the cases
    BehaviourEnum getRandomNonDefaultBehaviour()
    {
        if (Random.Range(0, 10) < 6)
        {
            return BehaviourEnum.Attack;
        }

        return BehaviourEnum.RunBackwards;
    }

}
