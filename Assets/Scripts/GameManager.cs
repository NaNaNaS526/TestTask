using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.SceneManagement.SceneManager;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private GameObject audioManager;
    [SerializeField] private GameObject canvas;

    [SerializeField] private Canvas gameCanvas;
    [SerializeField] private GameObject gameEndPanel;
    [SerializeField] private TextMeshProUGUI gameResultText;
    [SerializeField] private Button restartGameButton;
    [SerializeField] private GameObject _middleLine;

    [SerializeField] private SlotForDraggableElements gridCell4;
    [SerializeField] private SlotForDraggableElements gridCell5;
    [SerializeField] private SlotForDraggableElements gridCell6;

    private DraggableElement[] _draggableElements;

    private void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
        restartGameButton.onClick.AddListener(RestartGame);
        IndestructibleObjectsSettings();
        _draggableElements = gameCanvas.GetComponentsInChildren<DraggableElement>();
    }

    private void FixedUpdate()
    {
        if (gridCell4.isSlotEmpty == false & gridCell5.isSlotEmpty == false & gridCell6.isSlotEmpty == false)
        {
            _middleLine.GetComponent<Animator>().SetBool("IsDisappearing",true);
            ViewGameEndPanel("Victory", true);
        }
    }

    private void IndestructibleObjectsSettings()
    {
        DontDestroyOnLoad(gameCanvas);
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(audioManager);
    }

    private void StartGame()
    {
        LoadScene(1);
        startGameButton.gameObject.SetActive(false);
        gameCanvas.gameObject.SetActive(gameCanvas.gameObject.activeSelf == false);
    }

    public void ViewGameEndPanel(string result, bool isWon)
    {
        gameEndPanel.SetActive(true);
        gameResultText.text = result;
        if (isWon)
        {
            foreach (var a in _draggableElements)
            {
                var aPosition = a.GetComponent<RectTransform>();
                aPosition.position = a.startPosition;
            }
        }
    }

    private void RestartGame()
    {
        LoadScene(1);
        gridCell5.isSlotEmpty = true;
        gameEndPanel.SetActive(false);
    }
}