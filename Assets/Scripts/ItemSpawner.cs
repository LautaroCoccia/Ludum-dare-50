using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] GameObject[] Items;
    [SerializeField] float[] ProbabilidadDeSpawn;
    [SerializeField] float TimerSpawn;
    [SerializeField] Transform[] Spawnpoints;
    [SerializeField] bool[] isUsed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
