using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPatyDeCancha : ItemParent
{
    
    private void OnTriggerStay(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffPatyDeCancha();

            manager.OnDeleteObject(SpawnedOn);
            Destroy(gameObject);
            
        }
    }
}
