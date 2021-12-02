using UnityEngine;

public class Score : MonoBehaviour
{
    public int CurrentScore { get; private set; }
    public bool IsHightScore { get; private set; }

    [SerializeField] private GameplayUIViewer _viewer;

    private int _hightScore;

    private void Awake()
    {
        _hightScore = GameData.LoadHightScore();
    }

    public void AddScore(int score)
    {
        CurrentScore += score;

        if (CurrentScore > _hightScore)
        {
            _hightScore = CurrentScore;
            IsHightScore = true;
        }

        _viewer.DisplayScore(CurrentScore);
    }

    public void SaveNewHightScore()
    {
        GameData.SaveHightScore(_hightScore);
    }
}