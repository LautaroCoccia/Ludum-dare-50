using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShakira : ItemParent
{
    [SerializeField] float effectTime;

    private void Awake()
    {
        Type = 1;
    }

    private void OnTriggerStay(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffShakira(effectTime);

            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject);
        }
    }
}
