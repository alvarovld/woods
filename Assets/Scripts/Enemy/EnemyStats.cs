using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float health;

    void Start()
    {
        health = 100;
    }

    public void reduceHealth(float amount)
    {
        health -= amount;
    }

    private void Update()
    {
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
