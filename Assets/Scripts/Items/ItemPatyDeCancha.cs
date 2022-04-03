using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPatyDeCancha : MonoBehaviour
{
    [SerializeField] AudioSource pati;
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("Colided: " + collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Player"))
        {
            pati.Play();
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffPatyDeCancha();
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, pati.clip.length);
        }
    }
}
