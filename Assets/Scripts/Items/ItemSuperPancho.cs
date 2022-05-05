using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemSuperPancho : ItemParent
{
    [SerializeField] AudioSource noise;
    private void Awake()
    {
        
            Type = 2;
        
    }

    private string getSuperPancho()
    {
        return "superPancho";
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
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            AnalyticsResult analyticsResult = Analytics.CustomEvent("PickUp_SuperPancho" + getSuperPancho());
            Debug.Log("superPanchoResult: " + analyticsResult);
            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);

        }
    }
}
