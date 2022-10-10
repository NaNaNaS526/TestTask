using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform startTransform;
    public Vector3 lastPosition;

    private Canvas _mainCanvas;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    public bool isInSlot;
    public Vector3 startPosition;
    [SerializeField] private SlotForDraggableElements slot;

    private void Start()
    {
        _mainCanvas = GetComponentInParent<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();

        startPosition = startTransform.position;
        _rectTransform.position = startPosition;
        lastPosition = startPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _canvasGroup.blocksRaycasts = false;
        isInSlot = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _mainCanvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (!isInSlot)
        {
            _rectTransform.position = lastPosition;
            return;
        }
        SlotForDraggableElements? testSlot = eventData.pointerEnter.transform.gameObject.GetComponent<SlotForDraggableElements>();
        if (testSlot != null)
        {
            slot.isSlotEmpty = true;
            slot = testSlot;
        }
        _canvasGroup.blocksRaycasts = true;
    }
}