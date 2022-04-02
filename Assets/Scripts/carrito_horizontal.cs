using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrito_horizontal : MonoBehaviour
{
    private Vector3 carrito_vector;
    public GameObject Player;
    public Rigidbody carrito_rigid_body;
    public int speed = 8;


    void Start()
    {
        if (transform.position.z <= -1)
        {
            speed = speed * -1;
        }
    }

    void Update()
    {
        carrito_vector = new Vector3(1, 0, 0);
        carrito_run_run();
    }

    public void carrito_run_run()
    {
        Vector3 MoveVector = transform.TransformDirection(carrito_vector) * speed;
        carrito_rigid_body.velocity = new Vector3(MoveVector.x, carrito_rigid_body.velocity.y, MoveVector.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            collision.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(false);
        }
        if (collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject == Player)
        {
            collision.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(false);
        }
        if (collision.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
