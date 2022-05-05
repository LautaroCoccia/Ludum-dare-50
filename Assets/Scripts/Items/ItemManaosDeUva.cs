using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemManaosDeUva : ItemParent
{
    [SerializeField] float effectTime;
    [SerializeField] AudioSource noise;
    private void Awake()
    {
        Type = 0;
    }


    private string getManaosUva()
    {
        return "manaos";
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnManaos(effectTime);
            noise.Play();
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            AnalyticsResult analyticsResult = Analytics.CustomEvent("PickUp_ManaosUva" +  getManaosUva());         
            Debug.Log("manaosUvaResult: " + analyticsResult);

            if (manager != null)
            {
                manager.OnDeleteObject(this,SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);
        }
    }
}
