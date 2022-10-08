using UnityEngine;
using UnityEngine.EventSystems;

public class SlotForDraggableElements : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        var slotPosition = transform.position;
        var draggableElement = otherItemTransform.GetComponent<DraggableElement>();

        draggableElement.isInSlot = true;
        draggableElement.lastPosition = slotPosition;
        otherItemTransform.gameObject.GetComponent<RectTransform>().position = slotPosition;
    }
}