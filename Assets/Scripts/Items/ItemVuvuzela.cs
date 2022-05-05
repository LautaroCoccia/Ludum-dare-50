using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class ItemVuvuzela : ItemParent
{
    [SerializeField] float effectTime;
    [SerializeField] Vector3 DamageSize;
    [SerializeField] AudioSource noise;

    public string getVuvuzela()
    {
        return "vuvuzela";
    }

    private void OnTriggerStay(Collider collider)
    {


        if (collider.gameObject.CompareTag("Player"))
        {
            noise.Play();
            GetComponent<CapsuleCollider>().enabled = false;
            GetComponentInChildren<SpriteRenderer>().enabled = false;
            AnalyticsResult analyticsResult = Analytics.CustomEvent("PickUp_Vuvuzela" + getVuvuzela());
            Debug.Log("vuvuzelaResults: " + analyticsResult);
            foreach (RaycastHit raycastHit in Physics.BoxCastAll(gameObject.transform.position, DamageSize, transform.forward, transform.rotation))
            {
                if (raycastHit.transform.CompareTag("Enemy"))
                {
                    raycastHit.transform.GetComponent<EnemyScript>().Stunned(effectTime);
                }


            }
            Camera.main.GetComponent<CameraController>().OnCameraShake(1, new Vector3(2, 0, 0));
            if (manager != null)
            {
                manager.OnDeleteObject(this, SpawnedOn);

            }
            Destroy(gameObject, noise.clip.length);
        }
    }
}
