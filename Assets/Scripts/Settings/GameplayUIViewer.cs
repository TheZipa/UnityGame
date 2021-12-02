using UnityEngine;
using UnityEngine.UI;

public class GameplayUIViewer : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] private Image[] _hearts;
    [SerializeField] private HealthPoints _playerHealthPoints;

    [Header("Text")]
    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _ammoText;
    [SerializeField] private Text _noAmmoText;

    private void Awake()
    {
        _playerHealthPoints.OnHealthChanged += DisplayHealthPoints;
    }

    public void DisplayAmmo(int ammo)
    {
        _ammoText.text = ammo.ToString();
        _noAmmoText.gameObject.SetActive(ammo <= 0);
    }

    public void DisplayHealthPoints(int hp)
    {
        foreach(var heart in _hearts)
        {
            heart.gameObject.SetActive(hp > 0);
            hp--;
        }
    }

    public void DisplayScore(int score) => _scoreText.text = score.ToString();
}