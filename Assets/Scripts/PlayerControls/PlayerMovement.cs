using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void Move(float horizontal, float vertical)
    {
        Vector3 moveDirection = new Vector3(horizontal * _speed, _rigidbody.velocity.y, vertical * _speed);
        _rigidbody.velocity = moveDirection;
    }
}