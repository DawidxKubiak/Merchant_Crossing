using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : Draggable, IWeightable
{
    [Header("To sie losuje")]
    [SerializeField] int weight;

    private void Start()
    {
        weight = Random.Range(1, 30);
    }

    public int GetWeight()
    {
       return weight;
    }

    
}
