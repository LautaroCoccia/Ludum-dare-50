using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : EnemyScript
{
    void Update()
    {
        RB.velocity = new Vector3(Player.transform.position.x - transform.position.x, 0, Player.transform.position.z - transform.position.z).normalized * MovementSpeed;
    }
}
