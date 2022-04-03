using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTarjetaRoja : MonoBehaviour
{
    [SerializeField] Vector3 DamageSize;
    [SerializeField] AudioSource silbatazo;
    private void OnTriggerStay(Collider collider)
    {
        
        Debug.Log("Colided: " + collider.gameObject.name);
        if (collider.gameObject.CompareTag("Player"))
        {
            
            foreach (RaycastHit raycastHit in Physics.BoxCastAll(gameObject.transform.position, DamageSize, transform.forward,transform.rotation) )
            {
                if (raycastHit.transform.CompareTag("Enemy"))
                {
                    raycastHit.transform.GetComponent<EnemyScript>().Damaged();
                }
            }
            silbatazo.Play();
            GetComponent<CapsuleCollider>().enabled = false;
            Destroy(gameObject, silbatazo.clip.length);
        }
    }
}
