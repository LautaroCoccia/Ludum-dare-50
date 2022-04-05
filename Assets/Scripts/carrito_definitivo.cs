using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrito_definitivo : MonoBehaviour
{
    private Vector3 Carrito_vector;
    private Vector3 vector_norte = new Vector3(0, 0, 1);
    private Vector3 vector_sur = new Vector3(0, 0, -1);
    public GameObject Player;
    public int speed = 8;
    private AudioSource Mine;
    [SerializeField] SpriteRenderer sr;

    public Sprite front;
    public Sprite back;
    void Start()
    {
        if (transform.position.z <= -3)
        {
            Carrito_vector = vector_norte;
        }
        
        else if (transform.position.z >= 3)
        {
            Carrito_vector = vector_sur;
        }
        Mine = GetComponent<AudioSource>();

        if (transform.position.x > 0)
        {
            sr.sprite = back;
        }
        if (transform.position.x < 0)
        {
            sr.sprite = front;
        }

    }
    void Update()
    {
        if (transform.position.z >= -3)
        {
            transform.Translate(Carrito_vector * speed * Time.deltaTime);
        }
        else if (transform.position.z <= 3)
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
