using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShakira : ItemParent
{
    [SerializeField] float effectTime;
    private void OnTriggerStay(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffShakira(effectTime);

            manager.OnDeleteObject(SpawnedOn);
            Destroy(gameObject);
        }
    }
}
