using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody rb;
    [SerializeField] SpriteRenderer sr;

    [SerializeField] bool canJump = true;
    float hor;
    float ver;

    Vector3 movementDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxis("Horizontal");
        ver = Input.GetAxis("Vertical");
        movementDirection = new Vector3(hor, 0, ver);
        
        if(movementDirection.x < 0)
        {
            sr.flipX = true;
        }
        else if(movementDirection.x > 0)
        {
            sr.flipX = false;
        }
        //movementDirection.Normalize();
        //if (movementDirection != Vector3.zero)
        //{
        //    Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed * Time.deltaTime);
        //}
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(hor * movementSpeed, rb.velocity.y, ver * movementSpeed);

        if(Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            rb.AddForce(new Vector3(0, jumpForce), ForceMode.Impulse);
        }
        //if (movementDirection != Vector3.zero)
        //{
        //    Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //    rb.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Ground")
        {
            canJump = true;
        }
    }
}
