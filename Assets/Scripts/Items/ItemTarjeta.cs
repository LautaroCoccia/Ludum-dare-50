using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemTarjeta : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {

        Debug.Log("Colided: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Player"))
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
