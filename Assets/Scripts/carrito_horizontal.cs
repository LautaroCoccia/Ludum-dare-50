using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrito_horizontal : MonoBehaviour
{
    private Vector3 Carrito_vector;
    private Vector3 vector_norte = new Vector3(1, 0, 0);
    private Vector3 vector_sur = new Vector3(-1, 0, 0);
    public GameObject Player;
    public int speed = 8;
    public SpriteRenderer sr;

    private AudioSource Mine;

    void Start()
    {
        if (transform.position.x <= -3)
        {
            Carrito_vector = vector_norte;
        }

        else if (transform.position.x >= 3)
        {
            Carrito_vector = vector_sur;
        }
        Mine = GetComponent<AudioSource>();
        
        
        if (transform.position.x > 0)
        {
            sr.flipX = true;
        }
        if (transform.position.x < 0)
        {
            sr.flipX = false;
        }

    }
    void Update()
    {
        if (transform.position.x >= -3)
        {
            transform.Translate(Carrito_vector * speed * Time.deltaTime);
        }
        else if (transform.position.x <= 3)
        {
            transform.Translate(Carrito_vector * speed * Time.deltaTime);

        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            collider.gameObject.GetComponent<PlayerMovement>().OnPlayerDamaged(false);

            if (Mine.isPlaying == false)
            {
                Mine.Play();
            }
        }
        
        if (collider.tag == "wall")
        {
            Destroy(this.gameObject);
        }
        if (collider.tag == "Enemy")
        {
            Destroy(collider.gameObject);

            if (Mine.isPlaying == false)
            {
                Mine.Play();
            }
        }
    }
}
