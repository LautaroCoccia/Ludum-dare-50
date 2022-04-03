using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSuperPancho : MonoBehaviour
{
    [SerializeField] float effectTime;
    [SerializeField] float multiplicadorVelocidad;
    [SerializeField] AudioSource �ami�ami;
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("Colided: " + collider.gameObject.tag);
        if (collider.gameObject.CompareTag("Player"))
        {
            �ami�ami.Play();
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffSuperPancho(effectTime, multiplicadorVelocidad);
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, �ami�ami.clip.length);
        }
    }
}
