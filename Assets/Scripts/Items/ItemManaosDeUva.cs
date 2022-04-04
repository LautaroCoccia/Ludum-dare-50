using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManaosDeUva : ItemParent
{
    [SerializeField] float effectTime;
    [SerializeField] AudioSource noise;
    private void Awake()
    {
        Type = 0;
    }

    private void OnTriggerStay(Collider collider)
    {

        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnManaos(effectTime);
            noise.Play();
            GetComponent<CapsuleCollider>().enabled = false;
            if (manager != null)
            {
                manager.OnDeleteObject(this,SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);
        }
    }
}
