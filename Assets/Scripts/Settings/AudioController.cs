using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource[] _sounds;
    [SerializeField] private AudioSource _music;
    [SerializeField] private AudioSource _clickSound;

    public float MusicVolume { get; private set; }
    public float SoundsVolume { get; private set; }

    private void Start() => GameData.LoadAudioSettings(this);

    public void SetMusicVolume(float volume) => _music.volume = MusicVolume = volume;

    public void SetSoundsVolume(float volume)
    {
        for (int i = 0; i < _sounds.Length; i++)
            _sounds[i].volume = volume;

        _clickSound.volume = SoundsVolume = volume;
    }

    public void PlayClickSound() => _clickSound.Play();

    public void PlaySound(int soundIndex) => _sounds[soundIndex].Play();

    public void PlayLaserShotSound()
    {
        _sounds[0].pitch = Random.Range(0.9f, 1.1f);
        _sounds[0].Play();
    }
}