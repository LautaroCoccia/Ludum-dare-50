using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViajero : MonoBehaviour
{
    [SerializeField] float effectTime;
    [SerializeField] Vector3 effectForce;
    [SerializeField] AudioSource escabio;

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            escabio.Play();
            Camera.main.GetComponent<CameraController>().OnCameraShake(effectTime, effectForce);
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, escabio.clip.length);
        }
    }
}
