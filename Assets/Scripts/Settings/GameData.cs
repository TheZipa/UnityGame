using UnityEngine;

public class GameData
{
    public static void SaveAudioSettings(AudioController _audioController)
    {
        PlayerPrefs.SetFloat("MusicVolume", _audioController.MusicVolume);
        PlayerPrefs.SetFloat("SoundsVolume", _audioController.SoundsVolume);
        PlayerPrefs.Save();
    }

    public static void SaveHightScore(int hightscore)
    {
        PlayerPrefs.SetInt("HightScore", hightscore);
    }

    public static void LoadAudioSettings(AudioController _audioController)
    {
        if(PlayerPrefs.HasKey("MusicVolume") && PlayerPrefs.HasKey("SoundsVolume"))
        {
            _audioController.SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
            _audioController.SetSoundsVolume(PlayerPrefs.GetFloat("SoundsVolume"));
        }
        else
        {
            _audioController.SetMusicVolume(.35f);
            _audioController.SetSoundsVolume(.35f);
            SaveAudioSettings(_audioController);
        }
    }

    public static int LoadHightScore()
    {
        if(PlayerPrefs.HasKey("HightScore"))
        {
            return PlayerPrefs.GetInt("HightScore");
        }
        else
        {
            SaveHightScore(0);
            return 0;
        }
    }
}