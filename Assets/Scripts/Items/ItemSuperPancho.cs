using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSuperPancho : ItemParent
{
    [SerializeField] AudioSource noise;
    private void Awake()
    {
        
            Type = 2;
        
    }

    [SerializeField] float effectTime;
    [SerializeField] float multiplicadorVelocidad;
    private void OnTriggerStay(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffSuperPancho(effectTime, multiplicadorVelocidad);
            noise.Play();
            GetComponent<CapsuleCollider>().enabled = false;
            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);

        }
    }
}
