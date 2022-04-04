using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] protected float MovementSpeed;
    [SerializeField] protected GameObject Player;
    protected Rigidbody RB;
    protected Coroutine StunnedRoutine;
    protected bool stunned;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    

    virtual public void Damaged()
    {
        //Efectos al destruir a este enemigo
        Destroy(gameObject);
    }
    virtual public void Stunned(float EffectTime)
    {
        if(StunnedRoutine!= null)
        {
            StopCoroutine(StunnedRoutine);
        }
        //Efectos al estunear a este enemigo
        StunnedRoutine = StartCoroutine(StunnedEnemy(EffectTime));
    }

    virtual protected IEnumerator StunnedEnemy(float EffectTime)
    {
        
        stunned = true;
        float _savedSpeed = MovementSpeed;
        MovementSpeed = 0;
        float Timer = EffectTime;
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }
        stunned = false;
        MovementSpeed = _savedSpeed;
    }


    virtual protected void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == Player & StunnedRoutine == null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(false);
        }
    }
    virtual protected void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == Player & StunnedRoutine == null)
        {
            collision.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(false);
        }
    }
}
