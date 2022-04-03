using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVuvuzela : ItemParent
{
    [SerializeField] float effectTime;
    [SerializeField] Vector3 DamageSize;

    private void OnTriggerStay(Collider collider)
    {

        
        if (collider.gameObject.CompareTag("Player"))
        {
            foreach(RaycastHit raycastHit in Physics.BoxCastAll(gameObject.transform.position, DamageSize, transform.forward,transform.rotation) )
            {
                if (raycastHit.transform.CompareTag("Enemy"))
                {
                    raycastHit.transform.GetComponent<EnemyScript>().Stunned(effectTime);
                }
            }
            manager.OnDeleteObject(SpawnedOn);
            Destroy(gameObject);
        }
    }
}
