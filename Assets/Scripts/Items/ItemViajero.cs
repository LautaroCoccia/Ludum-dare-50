using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemViajero : ItemParent
{
    [SerializeField] float effectTime;
    [SerializeField] Vector3 effectForce;
    [SerializeField] AudioSource noise;

    public string getFernet()
    {
        return "fernet";
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Camera.main.GetComponent<CameraController>().OnCameraShake(effectTime, effectForce);
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            noise.Play();
            AnalyticsResult analyticsResult = Analytics.CustomEvent("PickUp_Fernet" + getFernet());
            Debug.Log("fernetResults: " + analyticsResult);
            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);
        }
    }
}
