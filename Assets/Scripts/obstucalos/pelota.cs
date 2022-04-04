using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelota : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TimeAlive());
    }
    private void OnTriggerEnter(Collider collider)
    {

        Debug.Log("Colided: " + collider.gameObject.name);
        if (collider.gameObject.CompareTag("Player"))
        {
            collider.gameObject.GetComponent<PlayerMovement>().pelotazo();
        }
    }

    IEnumerator TimeAlive()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
}
