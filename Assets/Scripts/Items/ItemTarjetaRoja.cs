using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemTarjetaRoja : ItemParent
{
    [SerializeField] Vector3 DamageSize;
    [SerializeField] AudioSource noise;
    private void Awake()
    {
        Type = 4;
    }

    public string getTarjetaRoja()
    {
        return tarjeta;
    }

    public string tarjeta = "tarjetaRoja";

    private void OnTriggerStay(Collider collider)
    {

        
        if (collider.gameObject.CompareTag("Player"))
        {
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            noise.Play();
            //AnalyticsResult analyticsResult = Analytics.CustomEvent("PickUp_TarjetaRoja", getTarjetaRoja());
            //Debug.Log("tarjetaRojaResult: " + analyticsResult);
            foreach (RaycastHit raycastHit in Physics.BoxCastAll(gameObject.transform.position, DamageSize, transform.forward,transform.rotation) )
            {
                if (raycastHit.transform.CompareTag("Enemy"))
                {
                    raycastHit.transform.GetComponent<EnemyScript>().Damaged();
                }
            }
            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);
        }
    }
}
