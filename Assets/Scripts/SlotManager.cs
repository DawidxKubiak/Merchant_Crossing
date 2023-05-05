using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotManager : MonoBehaviour
{
    public float spacing = 1f;

    private void Start()
    {
        UpdatePositions();
    }

    public void UpdatePositions()
    {
        int childCount = transform.childCount;
        if (childCount == 0) return;

        float totalWidth = (childCount - 1) * spacing;
        float startX = -totalWidth / 2;

        for (int i = 0; i < childCount; i++)
        {
            Transform child = transform.GetChild(i);
            Vector3 newPosition = new Vector3(startX + i * spacing, 0, 0);
            child.localPosition = newPosition;
        }

        LibraManager.instance.PrintWeights();
    }
}

