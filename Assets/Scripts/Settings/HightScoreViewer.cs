using UnityEngine;
using UnityEngine.UI;

public class HightScoreViewer : MonoBehaviour
{
    [SerializeField] private Text _hightScoreText;

    private void Awake()
    {
        _hightScoreText.text = GameData.LoadHightScore().ToString();
    }
}
