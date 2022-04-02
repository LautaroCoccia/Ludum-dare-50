using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_char : MonoBehaviour
{
    private Vector3 player_vector;

    public Rigidbody player_body;   
    public int speed = 10;
    void Start()
    {
        
    }
    void Update()
    {
        player_vector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        mover_player();
    }

    public void mover_player()
    {
        Vector3 MoveVector = transform.TransformDirection(player_vector) * speed;
        player_body.velocity = new Vector3(MoveVector.x, player_body.velocity.y, MoveVector.z);
        Debug.Log(player_body.velocity);
    }
}
