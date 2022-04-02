using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pick_up_manager : MonoBehaviour
{
    public GameObject pick_up;
    public bool IsSpawningPickUps;
    public int[] cantPickUps;
    public int PickUpcounter;
    public int WaiTime = 3;
    public Transform[] spawners;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    public enum ActualEnemyState
    {
        Regular
    }
    public ActualEnemyState state;

    public void WaitTime(ActualEnemyState state)
    {
        switch (state)
        {
            case ActualEnemyState.Regular:
                WaiTime = 5;
                break;
            
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (IsSpawningPickUps)
        {
            for (int i = 0; i < cantPickUps[(int)state]; i++)
            {
                Instantiate(pick_up, spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity);
                
                
                yield return new WaitForSeconds(WaiTime);
            }
        }
    }   


}
