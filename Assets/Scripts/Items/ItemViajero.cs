using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViajero : ItemParent
{
    [SerializeField] float effectTime;
    [SerializeField] Vector3 effectForce;
<<<<<<< HEAD
    [SerializeField] AudioSource noise;

    private void Awake()
    {
        Type = 5;
    }

=======
    //Vector3 startPosition;
    Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
    }
>>>>>>> Taro
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
<<<<<<< HEAD
            Camera.main.GetComponent<CameraController>().OnCameraShake(effectTime, effectForce);
            GetComponent<CapsuleCollider>().enabled = false;
            noise.Play();
            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);
=======
            mainCamera.GetComponent<CameraController>().OnCameraShake(effectTime, effectForce);
            Destroy(gameObject);
>>>>>>> Taro
        }
    }
}
