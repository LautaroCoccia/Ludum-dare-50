using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViajero : ItemParent
{
    [SerializeField] float effectTime;
    [SerializeField] Vector3 effectForce;
    [SerializeField] AudioSource noise;

    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraController>().OnCameraShake(effectTime, effectForce);
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            noise.Play();
            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);
        }
    }
}
