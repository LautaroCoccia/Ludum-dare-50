using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] float MovementSpeed;
    [SerializeField] GameObject Player;
    Rigidbody RB;
    private Coroutine StunnedRoutine;
    
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
        if(StunnedRoutine!= null)
        {
            StopCoroutine(StunnedRoutine);
        }
        //Efectos al estunear a este enemigo
        StunnedRoutine = StartCoroutine(StunnedEnemy());
    }

    IEnumerator StunnedEnemy()
    {
        float _savedSpeed = MovementSpeed;
        MovementSpeed = 0;
        float Timer = 5;
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }

        MovementSpeed = _savedSpeed;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Player & StunnedRoutine == null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(false);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == Player & StunnedRoutine == null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(false);
        }
    }
}
