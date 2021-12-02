using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private LayerMask _playerLookMask;

    private Animator _animator;
    private HealthPoints _playerHealth;
    private Rigidbody _rigidbody;

    private Ray _lookAtMouseRay;
    private RaycastHit _lookAtMouseRaycastHit;

    private int _xHash;
    private int _yHash;
    private int _rotationHash;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerHealth = GetComponent<HealthPoints>();
        _rigidbody = GetComponent<Rigidbody>();

        _xHash = Animator.StringToHash("X");
        _yHash = Animator.StringToHash("Y");
        _rotationHash = Animator.StringToHash("Rotation");

        _playerHealth.OnDead += SetDeadAnimation;
    }

    private void SetDeadAnimation(GameObject player) => _animator.SetTrigger("PlayerDead");

    public void SetMoveAnimation(float horizontal, float vertical)
    {
        Vector3 inputDirection = new Vector3(horizontal, 0, vertical);
        Vector3 clampedDirection = Vector3.ClampMagnitude(inputDirection, 1);

        float x = Vector3.Dot(transform.right, clampedDirection);
        float y = Vector3.Dot(transform.forward, clampedDirection);

        _animator.SetFloat(_xHash, x);
        _animator.SetFloat(_yHash, y);
    }

    public void LookAtMouse()
    {
        _lookAtMouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_lookAtMouseRay, out _lookAtMouseRaycastHit, 25f, _playerLookMask))
            transform.LookAt(new Vector3(_lookAtMouseRaycastHit.point.x, transform.position.y, _lookAtMouseRaycastHit.point.z));
    }
}