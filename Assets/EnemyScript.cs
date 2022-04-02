using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    public float MovementSpeed;
    public Transform Objective;
    Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector3(Objective.position.x- transform.position.x, 0,Objective.position.z - transform.position.z).normalized * MovementSpeed;
    }
}
