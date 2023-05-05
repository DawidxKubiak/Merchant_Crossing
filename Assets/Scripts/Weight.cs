using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Weight : Draggable, IWeightable
{

    [SerializeField] TextMeshProUGUI text;
    public int weight;

    private void Start()
    {
        SetVisual();   
    }
    public void SetWeight(int amount)
    {
        weight = amount;
        SetVisual();
    }

    public int GetWeight()
    {
        return weight;
    }

    public void SetVisual()
    {
        text.text = $"{weight}";
    }

}
