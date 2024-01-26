using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (transform.childCount == 0)
        {
            GameObject dropped = eventData.pointerDrag;
            DragAbleItem dragAbleItem =  dropped.GetComponent<DragAbleItem>();
            dragAbleItem.parentAfterDrag = transform;
        }
    }
}
