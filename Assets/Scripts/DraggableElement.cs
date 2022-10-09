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
    private Vector3 _startPosition;

    private void Start()
    {
        _mainCanvas = GetComponentInParent<Canvas>();
        _rectTransform = GetComponent<RectTransform>();
        _canvasGroup = GetComponent<CanvasGroup>();

        _startPosition = startTransform.position;
        _rectTransform.position = _startPosition;
        lastPosition = _startPosition;
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
        }

        _canvasGroup.blocksRaycasts = true;
    }
}