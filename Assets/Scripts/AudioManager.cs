using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private Button soundSettingsButton;
    [SerializeField] private GameObject soundSettingsPanel;
    [SerializeField] private TextMeshProUGUI soundVolumeText;
    [SerializeField] private Slider soundVolumeSlider;

    private AudioSource _audioSource;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();

        soundVolumeSlider.value = PlayerPrefs.GetInt("SoundVolume");

        soundSettingsButton.onClick.AddListener(DisplaySoundSettingsPanel);
    }

    private void Update()
    {
        _audioSource.volume = soundVolumeSlider.value / 100;
        var soundVolume = (int)soundVolumeSlider.value;
        soundVolumeText.text = $"Sound: {soundVolume.ToString()}";
    }

    private void DisplaySoundSettingsPanel()
    {
        soundSettingsPanel.SetActive(soundSettingsPanel.activeSelf == false);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt("SoundVolume", (int)soundVolumeSlider.value);
    }
}