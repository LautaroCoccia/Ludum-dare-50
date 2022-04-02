using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPatyDeCancha : MonoBehaviour
{
    
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("Colided: " + collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffPatyDeCancha();
            Destroy(gameObject);
        }
    }
}
