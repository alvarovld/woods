using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSituationAwareness : MonoBehaviour
{
    FieldOfSight fieldOfSight;
    public Transform player;
    public float distanceToLosePlayer;
    bool enemyAwareOfPlayer;

    private void Start()
    {
        enemyAwareOfPlayer = false;
        fieldOfSight = GetComponent<FieldOfSight>();
    }

    float distanceToPlayer()
    {
        return (player.transform.position - transform.position).magnitude;
    }
    bool isFarEnoughFromPlayerToLoseHim()
    {
        return distanceToPlayer() >= distanceToLosePlayer;
    }

    public bool isEnemyAwayeOfPlayer()
    {
        return enemyAwareOfPlayer;
    }

    private void Update()
    {
        if (isFarEnoughFromPlayerToLoseHim())
        {
            //Debug.Log("[PlayerSituationAwareness] Player too far");
            enemyAwareOfPlayer = false;
            return;
        }
        else if (fieldOfSight.isTransformInFieldOfSight(player))
        {
            //Debug.Log("[PlayerSituationAwareness] Enemy sees player");
            enemyAwareOfPlayer = true;
        }
    }

}
