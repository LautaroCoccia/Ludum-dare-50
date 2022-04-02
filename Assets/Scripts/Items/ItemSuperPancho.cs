using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSuperPancho : MonoBehaviour
{
    [SerializeField] float effectTime;
    [SerializeField] float multiplicadorVelocidad;
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("Colided: " + collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffSuperPancho(effectTime, multiplicadorVelocidad);
            Destroy(gameObject);
        }
    }
}
