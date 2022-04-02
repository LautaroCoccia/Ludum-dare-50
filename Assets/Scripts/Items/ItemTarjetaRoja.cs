using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTarjetaRoja : MonoBehaviour
{

    private void OnTriggerStay(Collider collider)
    {

        Debug.Log("Colided: " + collider.gameObject.name);
        if (collider.gameObject.CompareTag("Player"))
        {
            foreach(RaycastHit raycastHit in Physics.BoxCastAll(gameObject.transform.position, new Vector3(9, 4, 9), transform.forward,transform.rotation) )
            {
                if (raycastHit.transform.CompareTag("Enemy"))
                {
                    raycastHit.transform.GetComponent<EnemyScript>().Damaged();
                }
            }
            Destroy(gameObject);
        }
    }
}
