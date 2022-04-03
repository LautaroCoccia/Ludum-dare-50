using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemViajero : ItemParent
{
    [SerializeField] float effectTime;
    [SerializeField] Vector3 effectForce;

    

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraController>().OnCameraShake(effectTime, effectForce);

            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject);
        }
    }
}
