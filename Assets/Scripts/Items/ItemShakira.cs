using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShakira : MonoBehaviour
{
    [SerializeField] float effectTime;
    [SerializeField] AudioSource chakira;
    private void OnTriggerStay(Collider collider)
    {
        Debug.Log("Colided: " + collider.gameObject.name);
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffShakira(effectTime);
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, chakira.clip.length);
        }
    }
}
