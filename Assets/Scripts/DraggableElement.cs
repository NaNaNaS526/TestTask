using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableElement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] private RectTransform startPosition;
    public Vector3 lastPosition;

    private Canvas _mainCanvas;
    private RectTransform _rectTransform;
    private CanvasGroup _canvasGroup;
    public bool isInSlot;

    private void Start()
    {
        _mainCanvas = GetComponentInParent<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();
        
        _rectTransform.position = startPosition.position;
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
            if (lastPosition != null)
            {
                _rectTransform.position = lastPosition;
            }
            else
            {
                _rectTransform.position = startPosition.position;
            }
        }

        _canvasGroup.blocksRaycasts = true;
    }
}