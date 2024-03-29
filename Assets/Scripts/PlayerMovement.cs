using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlayerMovement : MonoBehaviour
{
    public static Action OnDie;
    public float movementSpeed;
    [SerializeField] float rotationSpeed;
    [SerializeField] float jumpForce;
    [SerializeField] Rigidbody rb;
    [SerializeField] SpriteRenderer sr;
    [SerializeField] AudioSource RunRun;
    [SerializeField] bool isMoving;

    [SerializeField] Animator myanim;

    [SerializeField] GameObject[] Icons;

    [SerializeField] bool canJump = true;
    float hor;
    float ver;

    private bool isInvulnerable;
    private bool isShielded;
    Coroutine ShakiraRoutine;
    Coroutine ManaosRoutine;
    private int manaosInverseEffect;
    bool lost;

    Vector3 movementDirection;

    GameObject mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        sr = GetComponentInChildren<SpriteRenderer>();
        mainCamera = Camera.main.gameObject;
        myanim = GetComponentInChildren<Animator>();
        lost = false;
        manaosInverseEffect = 1;
    }

    // Update is called once per frame
    void Update()
    {
        hor = Input.GetAxisRaw("Horizontal");
        ver = Input.GetAxisRaw("Vertical");
        movementDirection = new Vector3(hor * manaosInverseEffect, 0, ver * manaosInverseEffect).normalized;

        if (rb.velocity.magnitude == 0)
        {
            myanim.speed = 0;
        }
        else
        {
            myanim.speed = 1;
        }

        if (isMoving == true && lost == false)
        {
            if (!RunRun.isPlaying)
            {
                RunRun.Play();
            }
        }
        else
        {
            RunRun.Stop();
        }

        

             
        if(movementDirection.x <0)
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
        rb.velocity = new Vector3(movementDirection.x * movementSpeed, rb.velocity.y, movementDirection.z * movementSpeed);

        

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

    public void OnPlayerDamaged(bool _Lethal)
    {
        if(isInvulnerable == false && ShakiraRoutine == null)
        {
            if (isShielded == false)
            {
                //EL JUGADOR MUERE
                ///ejecutar animaciones y dem�s
                lost = true;
                RunRun.Stop();

                AudioSource[] cameraSound = mainCamera.GetComponents<AudioSource>();
                Debug.Log(cameraSound.Length);

                Icons[0].SetActive(false);
                Icons[1].SetActive(false);
                Icons[2].SetActive(false);
                Icons[3].SetActive(false);


                cameraSound[0].Stop();
                cameraSound[1].Stop();
                cameraSound[2].Play();
                OnDie?.Invoke(); 
            }
            else
            {
               
                isShielded = false;
                mainCamera.GetComponent<CameraController>().OnCameraShake(1,new Vector3(1,1,0));
                Icons[3].SetActive(false);
                StartCoroutine(PlayerInvulnerabilityWindow());
            }
        }
        else
        {
            
        }
        
    }

    
    #region Items Y sus timers

    //el jugador recibe el escudo
    public void OnPlayerBuffPatyDeCancha()
    {
        isShielded = true;
        Icons[3].SetActive(true);
    }

    //cuando se rompe el escudo, se ejecuta esto:
    IEnumerator PlayerInvulnerabilityWindow()
    {
        isInvulnerable = true;
        float Timer = 1;
        //bucle que se repite, para animaci�nes o efectos
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
        Icons[1].SetActive(true);
        ShakiraRoutine = StartCoroutine(PlayerShakiraEffect(Tiempo));
    }

    IEnumerator PlayerShakiraEffect(float Tiempo)
    {
        
        float Timer = Tiempo;
        //bucle que se repite, para animaci�nes o efectos
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }
        Icons[1].SetActive(false);
        ShakiraRoutine = null;
    }

    public void OnPlayerBuffSuperPancho(float Tiempo, float multiplicadorVelocidad)
    {
        Icons[2].SetActive(true);
        StartCoroutine(PlayerPattyBuff(Tiempo, multiplicadorVelocidad));
    }

    IEnumerator PlayerPattyBuff(float Tiempo, float multiplicadorVelocidad)
    {
        
        movementSpeed += multiplicadorVelocidad;
        float Timer = Tiempo;
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }

        movementSpeed -= multiplicadorVelocidad;
        Icons[2].SetActive(false);
    }


    public void OnManaos(float Tiempo)
    {

        //si el efecto shakira esta activo, se resetea el timer
        if (ManaosRoutine != null)
        {
            StopCoroutine(ManaosRoutine);

        }
        Icons[0].SetActive(true);
        ManaosRoutine = StartCoroutine(ManaosEffect(Tiempo));
    }

    IEnumerator ManaosEffect(float Tiempo)
    {
        float Timer = Tiempo;
        manaosInverseEffect = -1;
        //bucle que se repite, para animaci�nes o efectos
        while (Timer > 0)
        {
            yield return 0;
            Timer -= Time.deltaTime;
        }
        manaosInverseEffect = 1;
        ManaosRoutine = null;
        Icons[0].SetActive(false);
    }

    public void bochazo()
    {
        StartCoroutine(pelotazo());
    }

    public IEnumerator pelotazo()
    {
        movementSpeed = 0;
        yield return new WaitForSeconds(2f);
        movementSpeed = 8.5f;
    }

    #endregion
}
