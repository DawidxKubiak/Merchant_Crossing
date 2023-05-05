using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private GameObject draggedObject;
    private Vector3 offset;

    private void OnMouseDown()
    {
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        draggedObject = gameObject;
    }

    private void OnMouseDrag()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
        draggedObject.transform.position = newPosition;
    }

   private void OnMouseUp()
{
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    Collider2D[] hitColliders = Physics2D.OverlapCircleAll(mousePosition, 0.1f);

    bool slotFound = false;

    foreach (Collider2D hitCollider in hitColliders)
    {
        if (hitCollider.gameObject.CompareTag("Slot"))
        {
            draggedObject.transform.SetParent(hitCollider.gameObject.transform);

            SlotManager slotManager = hitCollider.gameObject.GetComponent<SlotManager>();
            if (slotManager != null)
            {
                slotManager.UpdatePositions();
            }

            slotFound = true;
            break;
        }
    }

    if (!slotFound)
    {
        draggedObject.transform.SetParent(null);
            LibraManager.instance.PrintWeights();
    }
}
}