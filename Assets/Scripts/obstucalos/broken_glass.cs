using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class broken_glass : MonoBehaviour
{
    public AudioSource vidrio_estallado;

    public void Start()
    {
        StartCoroutine(TimeAlive());
    }

    private void OnTriggerEnter(Collider collider)
    {
       
        Debug.Log("Colided: " + collider.gameObject.name);
        if (collider.gameObject.CompareTag("Player"))
        {
            PlayerMovement player = collider.gameObject.GetComponent<PlayerMovement>();
            player.movementSpeed = player.movementSpeed / 2;


        }
    }

    private void OnTriggerExit(Collider collider)
    {
        Debug.Log("salió: " + collider.gameObject.name);
        PlayerMovement player = collider.gameObject.GetComponent<PlayerMovement>();
        player.movementSpeed = player.movementSpeed * 2;
    }


    IEnumerator TimeAlive()
    {
        yield return new WaitForSeconds(6f);
        Destroy(gameObject);
    }

}
