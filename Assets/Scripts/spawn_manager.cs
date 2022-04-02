using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_manager : MonoBehaviour
{
    public GameObject Enemies;
    public bool IsSpawningEnemies;
    public int[] cantEnemies;
    public int enemycounter;
    public int WaiTime = 2;
    public Transform[] spawners;

    public enum ActualEnemyState
    {
        easy,
        normal,
        hard
    }
    public ActualEnemyState state;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        
    }

    public void WaitTime(ActualEnemyState state)
    {
        switch (state)
        {
            case ActualEnemyState.easy:
                WaiTime = 5;
                break;
            case ActualEnemyState.normal:
                WaiTime = 3;
                break;
            case ActualEnemyState.hard:
                WaiTime = 1;
                break;
            default:
                break;
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (IsSpawningEnemies)
        {
            for (int i = 0; i < cantEnemies[(int)state]; i++)
            {
                Instantiate(Enemies, spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity);
                enemycounter++;
                WaitTime(state);
                yield return new WaitForSeconds(WaiTime);
            }
        }
    }

}
