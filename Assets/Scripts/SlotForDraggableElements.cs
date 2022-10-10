
using UnityEngine;
using UnityEngine.EventSystems;


public class SlotForDraggableElements : MonoBehaviour, IDropHandler
{
    [SerializeField] private int slotID;

    private GameManager _gameManager;
    private readonly int[] _availableSlots = { 4, 5, 6, 10, 11 };
    public bool isSlotEmpty = true;

    private void Start()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        if (slotID == 4 | slotID == 6 | slotID == 10)
        {
            isSlotEmpty = false;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (isSlotEmpty)
        {
            var otherItemTransform = eventData.pointerDrag.transform;
            var slotPosition = transform.position;
            var draggableElement = otherItemTransform.GetComponent<DraggableElement>();

            foreach (var a in _availableSlots)
            {
                if (slotID == a)
                {
                    draggableElement.GetComponent<DraggableElement>().isInSlot = true;
                    draggableElement.GetComponent<DraggableElement>().lastPosition = slotPosition;
                    otherItemTransform.gameObject.GetComponent<RectTransform>().position = slotPosition;
                    isSlotEmpty = false;
                    return;
                }
            }
        }
        
        _gameManager.ViewGameEndPanel("Mistake", false);
    }
}