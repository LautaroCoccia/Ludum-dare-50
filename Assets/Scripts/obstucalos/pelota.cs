using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pelota : MonoBehaviour
{
    public AudioSource noise;
    void Start()
    {
        StartCoroutine(TimeAlive());
    }
    private void OnTriggerEnter(Collider collider)
    {

        Debug.Log("Colided: " + collider.gameObject.name);
        if (collider.gameObject.CompareTag("Player"))
        {
            GetComponent<BoxCollider>().enabled = false;
            GetComponent<SpriteRenderer>().enabled = false;
            collider.gameObject.GetComponent<PlayerMovement>().bochazo();
        }
    }

    IEnumerator TimeAlive()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }
}
