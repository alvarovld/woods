using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{

    public GameObject player;
    public float distanceToDespawn;


    void Update()
    {
        destroyWhenFarAway();
    }

    void destroyWhenFarAway()
    {
        if ((player.transform.position - gameObject.transform.position).magnitude > distanceToDespawn)
        {
            Destroy(gameObject);
        }
    }
}
