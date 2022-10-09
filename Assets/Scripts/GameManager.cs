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
    


    private void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
        restartGameButton.onClick.AddListener(RestartGame);
        IndestructibleObjectsSettings();
        
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

    public void ViewGameEndPanel(string result)
    {
        gameEndPanel.SetActive(true);
        gameResultText.text = result;
    }

    private void RestartGame()
    {
        LoadScene(1);
        gameEndPanel.SetActive(false);
    }
}