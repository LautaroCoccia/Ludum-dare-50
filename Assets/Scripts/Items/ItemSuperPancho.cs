using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSuperPancho : MonoBehaviour
{
    [SerializeField] float effectTime;
    [SerializeField] float multiplicadorVelocidad;
    [SerializeField] AudioSource ñamiñami;
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("Colided: " + collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Player"))
        {
            ñamiñami.Play();
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffSuperPancho(effectTime, multiplicadorVelocidad);
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, ñamiñami.clip.length);
        }
    }
}
