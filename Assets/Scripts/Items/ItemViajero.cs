using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViajero : MonoBehaviour
{
    [SerializeField] float effectTime;
    [SerializeField] Vector3 effectForce;
    //Vector3 startPosition;
    Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            mainCamera.GetComponent<CameraController>().OnCameraShake(effectTime, effectForce);
            Destroy(gameObject);
        }
    }
}
