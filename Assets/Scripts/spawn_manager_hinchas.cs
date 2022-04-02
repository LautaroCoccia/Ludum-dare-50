using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn_manager_hinchas : MonoBehaviour
{
    public GameObject Enemies;
    public bool IsSpawningEnemies;
    public int[] cantEnemies;
    public int enemycounter;
    public int WaiTime = 5;
    public Transform[] spawners;

    public enum ActualEnemyState
    {
        policia,
        hinchas
    }
    public ActualEnemyState state;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
        state = ActualEnemyState.policia;
    }

    public void WaitTime(ActualEnemyState state)
    {
        switch (state)
        {
            case ActualEnemyState.policia:
                WaiTime = 5;
                break;
            case ActualEnemyState.hinchas:
                WaiTime = 3;
                break;
            /*case ActualEnemyState.hincholicias:
                WaiTime = 1;
                break;*/
            default:
                break;
        }
    } //basicamente la wea esta sirve para bajar el tiempo entre spawns

    //corrutina de spawn continuo
    IEnumerator SpawnEnemies()
    {
        while (IsSpawningEnemies)
        {
            for (int i = 0; i < cantEnemies[(int)state]; i++)
            {
                Instantiate(Enemies, spawners[Random.Range(0, spawners.Length)].position, Quaternion.identity);
                enemycounter++;
                if (enemycounter == 5) { state = ActualEnemyState.hinchas; }
                WaitTime(state);
                yield return new WaitForSeconds(WaiTime);
            }
        }
    }
}
