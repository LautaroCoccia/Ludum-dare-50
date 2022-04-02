using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrito : MonoBehaviour
{
    private Vector3 carrito_vector;

    public Rigidbody carrito_rigid_body;
    public int speed = 8;
    
    void Start()
    {
        
    }

    void Update()
    {
        carrito_vector = new Vector3(0, 0, -1);

        carrito_run_run();
    }

    public void carrito_run_run()
    {
        Vector3 MoveVector = transform.TransformDirection(carrito_vector) * speed;
        carrito_rigid_body.velocity = new Vector3(MoveVector.x, carrito_rigid_body.velocity.y, MoveVector.z);
    }
}
