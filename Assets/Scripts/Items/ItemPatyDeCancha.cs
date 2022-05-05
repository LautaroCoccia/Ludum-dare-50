using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemPatyDeCancha : ItemParent
{
    [SerializeField] AudioSource noise;
    private void Awake()
    {
        Type = 3;
    }

    private string getPatyCancha()
    {
        return "paty";
    }
    private void OnTriggerStay(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffPatyDeCancha();
            noise.Play();
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            AnalyticsResult analyticsResult = Analytics.CustomEvent("PickUp_PatyCancha" + getPatyCancha());
            Debug.Log("patyCanchaResult: " + analyticsResult);
            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);
            
        }
    }
}
