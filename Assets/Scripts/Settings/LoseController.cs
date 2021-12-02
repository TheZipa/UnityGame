using UnityEngine;
using UnityEngine.UI;

public class LoseController : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private GameObject _loseView;
    [SerializeField] private GameObject _hightScoreText;
    [SerializeField] private Text _scoreText;
    [Header("Components")]
    [SerializeField] private GameObject _player;
    [SerializeField] private PauseController _pauseController;

    private HealthPoints _playerHealth;
    private Score _playerScore;

    private void Awake()
    {
        _playerHealth = _player.GetComponent<HealthPoints>();
        _playerScore = _player.GetComponent<Score>();

        _playerHealth.OnDead += OnPlayerDead;
    }

    private void OnPlayerDead(GameObject player)
    {
        _loseView.SetActive(true);
        _scoreText.text = $"Score: {_playerScore.CurrentScore}";

        if (_playerScore.IsHightScore == true)
        {
            _playerScore.SaveNewHightScore();
            _hightScoreText.SetActive(true);
        }
    }
}
