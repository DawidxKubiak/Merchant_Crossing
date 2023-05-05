using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LibraManager : MonoBehaviour
{
    #region singleton
    public static LibraManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion
    [SerializeField] List<IWeightable> leftSide = new();
    [SerializeField] List<IWeightable> rightSide = new();

    [SerializeField] Transform leftPlate, rightPlate;

    private void Start()
    {
        SetPlates();

        PrintWeights();
    }


    public void SetPlates()
    {
        leftSide.Clear();
        rightSide.Clear();

        foreach (Transform transform in leftPlate)
        {
            IWeightable weight = transform.GetComponent<IWeightable>();
            if(weight != null)
            {
                leftSide.Add(weight);
            }
        }

        foreach (Transform transform in rightPlate)
        {
            IWeightable weight = transform.GetComponent<IWeightable>();
            if (weight != null)
            {
                rightSide.Add(weight);
            }
        }
    }

    public void BalancePlates(int left, int right)
    {
        float offset;

        offset = -(left - right) * 0.1f; 

        leftPlate.DOMove(new Vector3(leftPlate.transform.position.x, offset,0),1f);
        rightPlate.DOMove(new Vector3(rightPlate.transform.position.x, -offset, 0), 1f);
        //rightPlate.transform.position = new Vector2(rightPlate.transform.position.x, -offset);
    }



    public void PrintWeights()
    {
        SetPlates();

        int left = 0;
        int right = 0;

        foreach (IWeightable weight in leftSide)
        {
            left += weight.GetWeight();
        }

        foreach (IWeightable weight in rightSide)
        {
            right += weight.GetWeight();
        }

        BalancePlates(left, right);

        Debug.Log($"== {left} == vs == {right} ==");
    }
}
