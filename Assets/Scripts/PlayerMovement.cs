using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] bool canJump;
    [SerializeField] Rigidbody rb;
    [SerializeField] SpriteRenderer sr;
    float hor;
    float ver;

    private bool isInvulnerable;
    private bool isShielded;
    Coroutine ShakiraRoutine;

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
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector3(hor, 0, ver);

        /*      Silenciado temporalmente hasta tener sprites
        if(movementDirection.x <0)
        {
            sr.flipX = true;
        }
        else if(movementDirection.x > 0)
        {
            sr.flipX = false;
        }
        */
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

        //if (movementDirection != Vector3.zero)
        //{
        //    Quaternion rotation = Quaternion.LookRotation(movementDirection, Vector3.up);
        //    rb.rotation = Quaternion.RotateTowards(transform.rotation, rotation, rotationSpeed);
        //}
    }

    public void OnPlayerDamaged(bool _Lethal)
    {
        if(isInvulnerable == false)
        {
            if (isShielded == false)
            {
                //EL JUGADOR MUERE
                ///ejecutar animaciones y demás
                Debug.Log("KILL LA KILL");
            }
            else
            {
                Debug.Log("BLOQUEADO!!");
                isShielded = false;
                StartCoroutine(PlayerInvulnerabilityWindow());
            }
        }
        else
        {
            Debug.Log("IIINMOOORTAAAALLL!!!");
        }
        
    }

    #region Items Y sus timers

    //el jugador recibe el escudo
    public void OnPlayerBuffSuperPancho()
    {
        isShielded = true;
    }

    //cuando se rompe el escudo, se ejecuta esto:
    IEnumerator PlayerInvulnerabilityWindow()
    {
        isInvulnerable = true;
        float Timer = 1;
        //bucle que se repite, para animaciónes o efectos
        while (Timer>0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }
        
        isInvulnerable = false;
    }
    
    
    public void OnPlayerBuffShakira()
    {
        //si el efecto shakira esta activo, se resetea el timer
        if (ShakiraRoutine != null)
        {
            StopCoroutine(ShakiraRoutine);
            
        }
        ShakiraRoutine = StartCoroutine(PlayerShakiraEffect());
    }

    IEnumerator PlayerShakiraEffect()
    {
        isInvulnerable = true;
        float Timer = 5;
        //bucle que se repite, para animaciónes o efectos
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }

        isInvulnerable = false;
        ShakiraRoutine = null;
    }

    public void OnPlayerBuffPatty()
    {
        StartCoroutine(PlayerPattyBuff());
    }
    IEnumerator PlayerPattyBuff()
    {
        movementSpeed += 5;
        float Timer = 5;
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }

        movementSpeed -= 5;
    }

    #endregion
}
