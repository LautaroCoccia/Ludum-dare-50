using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParent : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(Timer());
    }

    [HideInInspector]
    public int Type;
    [HideInInspector]
    public int SpawnedOn;
    [HideInInspector]
    public pick_up_manager manager;

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(6);
    }

}
