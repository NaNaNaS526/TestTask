using UnityEngine;
using UnityEngine.EventSystems;

public class SlotForDraggableElements : MonoBehaviour, IDropHandler
{
    [SerializeField] private int slotID;

    private GameManager _gameManager;
    private readonly int[] _availableSlots = { 4, 5, 6, 10, 11 };

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        var slotPosition = transform.position;
        var draggableElement = otherItemTransform.GetComponent<DraggableElement>();

        foreach (var a in _availableSlots)
        {
            if (slotID == a)
            {
                draggableElement.isInSlot = true;
                draggableElement.lastPosition = slotPosition;
                otherItemTransform.gameObject.GetComponent<RectTransform>().position = slotPosition;
                return;
            }
        }

        _gameManager.ViewGameEndPanel("Mistake");
    }
}