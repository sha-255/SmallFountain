using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    [SerializeField] private Slider audioSlider;
    [SerializeField] private float standartVolume = .3f;
    [SerializeField] private string audioSafe = "audio";
    private AudioSource mainAudioSource;

    private void Awake()
    {
        if (PlayerPrefs.GetFloat(audioSafe) == 0)
            PlayerPrefs.SetFloat(audioSafe, standartVolume);
        mainAudioSource = GetComponent<AudioSource>();
        mainAudioSource.volume = PlayerPrefs.GetFloat(audioSafe);
        audioSlider.value = mainAudioSource.volume * 10;
        audioSlider.onValueChanged.AddListener(AudioChange);
    }

    private void AudioChange(float value)
    {
        mainAudioSource.volume = value / 10;
        PlayerPrefs.SetFloat(audioSafe, mainAudioSource.volume);
    }
}