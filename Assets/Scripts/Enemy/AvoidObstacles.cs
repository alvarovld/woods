using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvoidObstacles : MonoBehaviour
{

    void Start()
    {
        
    }

    bool isCollidingWithObstacle(Collision2D collision)
    {
        return collision.gameObject.tag.Equals(Dictionary.Tags.OBSTACLE);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isCollidingWithObstacle(collision))
        {
            return;
        }

        Vector3 obstaclePos = collision.transform.position;
        Vector3 direction = transform.position - obstaclePos;
        Vector3 perpendicular = Vector3.Cross(direction, Vector3.up).normalized;
    }
}
