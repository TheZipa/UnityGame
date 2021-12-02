using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerShooter))]
[RequireComponent(typeof(PlayerView))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField] private PauseController _pauseController;

    private PlayerMovement _playerMovement;
    private PlayerShooter _playerShooter;
    private PlayerView _playerView;
    private HealthPoints _playerHealth;

    private void Awake()
    {
        _playerView = GetComponent<PlayerView>();
        _playerShooter = GetComponent<PlayerShooter>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerHealth = GetComponent<HealthPoints>();
    }

    private void Update()
    {
        if(_pauseController.IsPaused == false && _playerHealth.IsAlive == true)
        {
            float horizontalAxis = Input.GetAxis("Horizontal");
            float verticalAxis = Input.GetAxis("Vertical");

            if (Input.GetButton("Fire1") && !IsMouseOverUI())
            {
                _playerShooter.Shoot();
            }

            _playerMovement.Move(horizontalAxis, verticalAxis);
            _playerView.LookAtMouse();
            _playerView.SetMoveAnimation(horizontalAxis, verticalAxis);
        }
    }

    private bool IsMouseOverUI() => EventSystem.current.IsPointerOverGameObject();
}