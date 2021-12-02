using UnityEngine;

public class PauseController : MonoBehaviour
{
    public bool IsPaused { get; private set; } = false;

    [SerializeField] private GameObject _pauseView;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ChangePauseState();
        }
    }

    public void ChangePauseState()
    {
        Time.timeScale = (IsPaused ? 1 : 0);
        IsPaused = !IsPaused;
        _pauseView.SetActive(IsPaused);
    }
}
