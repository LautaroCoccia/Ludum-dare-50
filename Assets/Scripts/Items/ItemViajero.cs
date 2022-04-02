using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViajero : MonoBehaviour
{
    [SerializeField] float effectTime;
    [SerializeField] Vector3 effectForce;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraController>().OnCameraShake(effectTime, effectForce);
            Destroy(gameObject);
        }
    }
}
