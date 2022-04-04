using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShakira : ItemParent
{
    [SerializeField] float effectTime;
    [SerializeField] AudioSource noise;

    

    private void OnTriggerStay(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffShakira(effectTime);
            noise.Play();
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);
        }
    }
}
