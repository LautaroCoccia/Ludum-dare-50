using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] float cameraSnappiness;
    [SerializeField] float cameraMaxSpeed;
    [SerializeField] float FollowPathStrenght;
    [SerializeField] Vector3 cameraOffset;

    [SerializeField] Vector3 shakeCameraPosition;
    Vector3 Speed;

    private GameObject player;
    private Rigidbody playerRB;

    private Coroutine shakingRoutine;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerRB = player.GetComponent<Rigidbody>();
        cameraOffset = transform.position - player.transform.position;
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 FixedPosition = shakeCameraPosition;
        //FixedCameraModifier = new Vector3( 0, 10, 0);
        Vector3 RealCameraOffset = cameraOffset + new Vector3(playerRB.velocity.x* FollowPathStrenght, 0, playerRB.velocity.z * FollowPathStrenght);

        Speed = Vector3.zero;
        Vector3 SmoothedVector = Vector3.SmoothDamp(transform.position + FixedPosition, player.transform.position + RealCameraOffset, ref Speed, cameraSnappiness * Time.deltaTime, cameraMaxSpeed );

        transform.position = SmoothedVector + FixedPosition;
    }

    #region CameraShake

    
    public void OnCameraShake(float shakeTime, Vector3 shakeAmount)
    {
        if(shakingRoutine != null)
        {
            StopCoroutine(shakingRoutine);

        }
        shakingRoutine = StartCoroutine(Shaker(shakeTime, shakeAmount));
    }
    IEnumerator Shaker(float shakeTime, Vector3 shakeAmount)
    {
        
        while (shakeTime > 0)
        {
            Vector3 RandomSphere = UnityEngine.Random.insideUnitSphere;
            shakeCameraPosition = new Vector3(RandomSphere.x * shakeAmount.x, RandomSphere.y * shakeAmount.y, RandomSphere.z * shakeAmount.z);
            shakeTime -= Time.deltaTime;
            yield return null;
        }
        shakeCameraPosition = Vector3.zero;
    }

    #endregion

}
