using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTaser : DefaultEnemy
{
    [SerializeField] float EnemyRange;
    [Space(4)]
    [SerializeField] float Windup;
    [SerializeField] float ActiveFrames;
    [SerializeField] float fallBack;
    protected override void Start()
    {
        base.Start();
        StartCoroutine(Pattern());
    }

    IEnumerator Pattern()
    {
        
        while (true)
        {
            while (stunned == false)
            {
                if (Vector3.Distance(Player.transform.position, transform.position) < EnemyRange)
                {
                    Vector3 LockOn = Player.transform.position;
                    //float DistanceToShot = 
                    RB.velocity = Vector3.zero;
                    yield return new WaitForSeconds(Windup);
                    //Physics.BoxCastAll();
                    yield return new WaitForSeconds(ActiveFrames);

                    yield return new WaitForSeconds(fallBack);
                }
                else
                {
                    RB.velocity = new Vector3(Player.transform.position.x - transform.position.x, 0, Player.transform.position.z - transform.position.z).normalized * MovementSpeed;
                }
                
                yield return null;
            }
            else
            {
                yield return null;
            }

        }
        
    }
}
