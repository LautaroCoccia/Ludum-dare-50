using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class El10s : EnemyScript
{
    

    void Update()
    {
        RB.velocity = new Vector3(Player.transform.position.x - transform.position.x, 0, Player.transform.position.z - transform.position.z).normalized * MovementSpeed;
    }

    override public void Damaged()
    {
        //Efectos al destruir a este enemigo
        Destroy(gameObject);
    }
    override public void Stunned(float EffectTime)
    {
        if (StunnedRoutine != null)
        {
            StopCoroutine(StunnedRoutine);
        }
        //Efectos al estunear a este enemigo
        StunnedRoutine = StartCoroutine(StunnedEnemy(EffectTime));
    }

    override protected IEnumerator StunnedEnemy(float EffectTime)
    {

        stunned = true;
        float _savedSpeed = MovementSpeed;
        MovementSpeed = 0;
        float Timer = EffectTime/3;
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }
        stunned = false;
        MovementSpeed = _savedSpeed;
    }


    override protected void OnCollisionEnter(Collision collision)
    {
        
    }
    override protected void OnCollisionStay(Collision collision)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player & StunnedRoutine == null)
        {
            other.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(true);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject == Player & StunnedRoutine == null)
        {
            other.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(true);
        }
    }
}
