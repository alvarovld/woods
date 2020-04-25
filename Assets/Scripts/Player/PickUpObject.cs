using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(!collider.gameObject.name.Equals(Dictionary.GameObjects.PLAYER))
        {
            return;
        }

        Inventory.GetInstance().add(gameObject);
        Destroy(this.gameObject);
    }
}
