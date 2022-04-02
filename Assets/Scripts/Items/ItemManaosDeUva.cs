using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManaosDeUva : MonoBehaviour
{
    [SerializeField] float effectTime;

    private void OnTriggerStay(Collider collider)
    {

        Debug.Log("Colided: " + collider.gameObject.name);
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnManaos(effectTime);
            Destroy(gameObject);
        }
    }
}
