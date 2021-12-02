using UnityEngine;
using UnityEngine.UI;

public class SoundSettings : MonoBehaviour
{
    [SerializeField] private AudioController _audioController;

    [Header("ValueTexts")]
    [SerializeField] private Text _musicValueText;
    [SerializeField] private Text _soundValueText;

    [Header("Sliders")]
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _soundsSlider;

    private void OnEnable()
    {
        _musicSlider.value = _audioController.MusicVolume;
        _soundsSlider.value = _audioController.SoundsVolume;

        SetVolumeValueText(_musicSlider, _musicValueText);
        SetVolumeValueText(_soundsSlider, _soundValueText);
    }

    private void OnDisable()
    {
        GameData.SaveAudioSettings(_audioController);
    }

    public void ChangeMusicVolume()
    {
        SetVolumeValueText(_musicSlider, _musicValueText);
        _audioController.SetMusicVolume(_musicSlider.value);
    }

    public void ChangeSoundsVolume()
    {
        SetVolumeValueText(_soundsSlider, _soundValueText);
        _audioController.SetSoundsVolume(_soundsSlider.value);
    }

    private void SetVolumeValueText(Slider slider, Text valueText)
    {
        valueText.text = string.Format("{0:0}", slider.value * 100);
    }
}