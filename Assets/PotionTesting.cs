using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PotionTesting : MonoBehaviour
{
    [SerializeField] Material potionMat;
    [SerializeField] Slider slider1, slider2;
    private void Awake()
    {
        potionMat = GetComponent<SpriteRenderer>().material;
    }
    public void ChangeSpeed()
    {
        float amount = slider1.value;
        Debug.Log(amount);
        potionMat.SetFloat("_Speed",amount);
    }

    public void ChangeSize()
    {
        float amount = slider2.value;
        potionMat.SetFloat("_Size", amount);
    }


}
