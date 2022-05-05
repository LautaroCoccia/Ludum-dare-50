using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemShakira : ItemParent
{
    [SerializeField] float effectTime;
    [SerializeField] AudioSource noise;

    private string getCassette()
    {
        return "cassette";
    }

    private void OnTriggerStay(Collider collider)
    {
        
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerBuffShakira(effectTime);
            noise.Play();
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            AnalyticsResult analyticsResult = Analytics.CustomEvent("PickUp_Cassette" + getCassette());
            Debug.Log("cassetteResult: " + analyticsResult);
            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);
        }
    }
}
