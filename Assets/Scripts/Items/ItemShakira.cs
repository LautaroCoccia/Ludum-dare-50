using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShakira : MonoBehaviour
{
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("Colided: " + collider.gameObject.name);
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffShakira();
            Destroy(gameObject);
        }
    }
}
