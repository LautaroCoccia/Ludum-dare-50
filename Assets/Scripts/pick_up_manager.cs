using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class pick_up_manager : MonoBehaviour
{
    public List<GameObject> agarrables;
    [Serializable]
    public class Position
    {
        public Transform pos;
        public bool isUsed;
        public int index;
    }
    public List<Position> positions;
    void Start()
    {
        for (int i = 0; i < positions.Count; i++)
            positions[i].index = i;
    }

    float timer = 0f;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 3)
        {
            SpawnStuff();
            timer = 0;
        }
    }

    public void SpawnStuff()
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
            int ind = UnityEngine.Random.Range(0, PositionsAux.Count);
            Instantiate(agarrables[UnityEngine.Random.Range(0, agarrables.Count)], PositionsAux[ind].pos.position , Quaternion.identity);
            ind = PositionsAux[ind].index;
            positions[ind].isUsed = true;
        }

        

    }

}
