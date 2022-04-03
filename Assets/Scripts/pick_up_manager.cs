using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pick_up_manager : MonoBehaviour
{
    [Serializable]
    public class PowerUps
    {
        public GameObject agarrable;
        public int percentileChance;
    }
    public List<PowerUps> PowerUpList;
    [Serializable]
    public class Position
    {
        public Transform pos;
        [HideInInspector]
        public bool isUsed;
        [HideInInspector]
        public int index;
    }
    public List<Position> positions;

    [SerializeField] int TimerSpawn;

    void Start()
    {
        for (int i = 0; i < positions.Count; i++)
            positions[i].index = i;
        
    }

    float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= TimerSpawn)
        {
            SpawnStuff();
            timer = 0;
        }
    }

    void SpawnStuff()
    {
        List<Position> PositionsAux = new List<Position>(positions);
        for (int i = 0; i < PositionsAux.Count; i++)
        {
            if (PositionsAux[i].isUsed)
            {
                PositionsAux.RemoveAt(i);
                i--;
            }
        }
        
        if (PositionsAux.Count > 0)
        {
            int Seed = UnityEngine.Random.Range(0, 100);
            Debug.Log("Chance: " + Seed);
            int Chance = PowerUpList[0].percentileChance;
            int indexAux = 0;
            while (Seed > Chance)
            {
                indexAux += 1;
                Chance += PowerUpList[indexAux].percentileChance;
                Debug.Log("debajo del limite: " + Chance);
            }

            int ind = UnityEngine.Random.Range(0, PositionsAux.Count);
            GameObject Prefab = Instantiate(PowerUpList[indexAux].agarrable, PositionsAux[ind].pos.position , Quaternion.identity);

            ItemParent auxIP = Prefab.GetComponent<ItemParent>();

            auxIP.SpawnedOn = PositionsAux[ind].index;
            auxIP.manager = this;
            positions[PositionsAux[ind].index].isUsed = true;
        }

        

    }

    public void OnDeleteObject(int i)
    {
        positions[i].isUsed = false;
        Debug.Log("id" + i + "liberated");
    }

}
