using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManaosDeUva : MonoBehaviour
{
    [SerializeField] float effectTime;
    [SerializeField] AudioSource nanaos;

    private void OnTriggerStay(Collider collider)
    {

        Debug.Log("Colided: " + collider.gameObject.name);
        if (collider.gameObject.CompareTag("Player"))
        {
            nanaos.Play();
            collider.gameObject.GetComponent<PlayerMovement>().OnManaos(effectTime);
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, nanaos.clip.length);
            
        }
    }
}
