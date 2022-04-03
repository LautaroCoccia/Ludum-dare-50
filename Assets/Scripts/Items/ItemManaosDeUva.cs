using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManaosDeUva : ItemParent
{
    [SerializeField] float effectTime;

    private void OnTriggerStay(Collider collider)
    {

        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnManaos(effectTime);
            if (manager != null)
            {
                manager.OnDeleteObject(SpawnedOn);

            }
            Destroy(gameObject);
        }
    }
}
