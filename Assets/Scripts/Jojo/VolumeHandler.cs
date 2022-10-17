using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeHandler : MonoBehaviour
{
    [SerializeField] private string volumeParameter = "MasterVolume";

    [SerializeField] private AudioMixer mixer;

    [SerializeField] private Slider slider;

    [SerializeField] private Toggle toggle;

    private const float multiplier = 30f;

    private bool disableToggleEvent;

    private float previousSliderValue;

    private void Awake()
    {
        slider.onValueChanged.AddListener(HandleSliderValueChanged);
        toggle.onValueChanged.AddListener(HandleToggleValueChanged);
    }

    private void HandleToggleValueChanged(bool eneableSound)
    {
        if (disableToggleEvent) return;

        slider.value = eneableSound ? previousSliderValue : slider.minValue;
    }

    private void OnDisable()
    {
        PlayerPrefs.SetFloat(volumeParameter, slider.value);
    }

    private void HandleSliderValueChanged(float value)
    {
        mixer.SetFloat(volumeParameter, Mathf.Log10(value) * multiplier);

        if(slider.value != slider.minValue)
            previousSliderValue = slider.value;

        disableToggleEvent = true;
        toggle.isOn = slider.value > slider.minValue;
        disableToggleEvent = false;
    }

    private void Start()
    {
        slider.value = PlayerPrefs.GetFloat(volumeParameter, slider.value);

        mixer.SetFloat(volumeParameter, Mathf.Log10(slider.value) * multiplier);
    }
}