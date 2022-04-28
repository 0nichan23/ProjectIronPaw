using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public Transform ParentToReturnTo = null;

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (TurnManager.Instance.LockInputs)
        {
            return;
        }

        ParentToReturnTo = transform.parent;
        transform.SetParent(transform.parent.parent);
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (TurnManager.Instance.LockInputs)
        {
            return;
        }
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (TurnManager.Instance.LockInputs)
        {
            return;
        }
        transform.SetParent(ParentToReturnTo);
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
