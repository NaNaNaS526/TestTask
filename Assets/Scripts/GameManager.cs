using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.SceneManagement.SceneManager;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button startGameButton;
    [SerializeField] private GameObject audioManager;
    [SerializeField] private GameObject canvas;

    private void Start()
    {
        startGameButton.onClick.AddListener(StartGame);
        IndestructibleObjectsSettings();
    }

    private void IndestructibleObjectsSettings()
    {
        DontDestroyOnLoad(canvas);
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(audioManager);
    }

    private void StartGame()
    {
        LoadScene(1);
        startGameButton.gameObject.SetActive(false);
    }
}