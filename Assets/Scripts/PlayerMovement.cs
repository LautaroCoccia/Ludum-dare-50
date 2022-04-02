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
    Coroutine ManaosRoutine;
    private int manaosInverseEffect;

    Vector3 movementDirection;

    GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponent<SpriteRenderer>();
        mainCamera = Camera.main.gameObject;

        manaosInverseEffect = 1;
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector3(hor * manaosInverseEffect, 0, ver * manaosInverseEffect);

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
        rb.velocity = new Vector3(movementDirection.x * movementSpeed, rb.velocity.y, movementDirection.z * movementSpeed);

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
                mainCamera.GetComponent<CameraController>().OnCameraShake(1,new Vector3(1,1,0));
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
    
    
    public void OnPlayerBuffShakira(float Tiempo)
    {
        //si el efecto shakira esta activo, se resetea el timer
        if (ShakiraRoutine != null)
        {
            StopCoroutine(ShakiraRoutine);
            
        }
        ShakiraRoutine = StartCoroutine(PlayerShakiraEffect(Tiempo));
    }

    IEnumerator PlayerShakiraEffect(float Tiempo)
    {
        isInvulnerable = true;
        float Timer = Tiempo;
        //bucle que se repite, para animaciónes o efectos
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }

        isInvulnerable = false;
        ShakiraRoutine = null;
    }

    public void OnPlayerBuffPatty(float Tiempo, float multiplicadorVelocidad)
    {
        StartCoroutine(PlayerPattyBuff(Tiempo, multiplicadorVelocidad));
    }

    IEnumerator PlayerPattyBuff(float Tiempo, float multiplicadorVelocidad)
    {
        
        movementSpeed *= multiplicadorVelocidad;
        float Timer = Tiempo;
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }

        movementSpeed /= multiplicadorVelocidad;
    }


    public void OnManaos(float Tiempo)
    {

        //si el efecto shakira esta activo, se resetea el timer
        if (ManaosRoutine != null)
        {
            StopCoroutine(ShakiraRoutine);

        }
        ManaosRoutine = StartCoroutine(ManaosEffect(Tiempo));
    }

    IEnumerator ManaosEffect(float Tiempo)
    {
        float Timer = Tiempo;
        manaosInverseEffect = -1;
        //bucle que se repite, para animaciónes o efectos
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }
        manaosInverseEffect = 1;
        ManaosRoutine = null;
    }

    #endregion
}
