using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotation : MonoBehaviour
{
    public float angleFix;
    public float speed;
    public Transform other;
    PlayerSituationAwareness situation;

    private void Start()
    {
        situation = GetComponent<PlayerSituationAwareness>();
    }
    void rotate()
    {
        Vector3 direction = transform.position - other.position;
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + angleFix;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, angle, 0), Time.deltaTime * speed);
    }

    private void Update()
    {
        if(situation.isEnemyAwayeOfPlayer())
        {
            rotate();
        }
    }


}
