using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public float MovementSpeed;
    public GameObject Player;
    Rigidbody RB;
    
    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector3(Player.transform.position.x- transform.position.x, 0, Player.transform.position.z - transform.position.z).normalized * MovementSpeed;
    }

    public void Damaged()
    {
        //Efectos al destruir a este enemigo
        Destroy(gameObject);
    }
    public void Stunned()
    {
        //Efectos al estunear a este enemigo
        StartCoroutine(StunnedEnemy());
    }

    IEnumerator StunnedEnemy()
    {
        MovementSpeed = 0;
        float Timer = 5;
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }

        MovementSpeed -= 5;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Player)
        {
            collision.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(false);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            collision.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(false);
        }
    }
}
