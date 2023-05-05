using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class ChangeMinigame : MonoBehaviour
{
    [SerializeField] Transform[] minigameTransform;
    [SerializeField] Image transition;

    public void Transition(int index)
    {
        Camera cam = Camera.main;
        cam.transform.position = minigameTransform[index].position + new Vector3(0, 0, -10);
    }
}
