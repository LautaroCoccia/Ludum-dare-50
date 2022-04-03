using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSuperPancho : ItemParent
{

    private void Awake()
    {
        
            Type = 2;
        
    }

    [SerializeField] float effectTime;
    [SerializeField] float multiplicadorVelocidad;
    private void OnTriggerStay(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffSuperPancho(effectTime, multiplicadorVelocidad);

            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject);

        }
    }
}
