using UnityEngine;

public class PlayerShooter : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private GameplayUIViewer _viewer;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private AudioController _audioController;

    [Header("Settings")]
    [SerializeField] private float _attackDelay;
    [SerializeField] private float _shotForce;
    [SerializeField] private int _ammoCount;

    private float _nextAttackTime;

    private void Awake()
    {
        _viewer.DisplayAmmo(_ammoCount);
    }

    public void AddAmmo(int ammo)
    {
        _ammoCount += ammo;
        _viewer.DisplayAmmo(_ammoCount);
    }

    public void Shoot()
    {
        if(_ammoCount != 0 && Time.time >= _nextAttackTime)
        {
            Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                Vector3 direction = hit.point - _shootPoint.position;
                direction.y = 0f;

                _nextAttackTime = Time.time + 1f / _attackDelay;

                GameObject bullet = Instantiate(_bulletPrefab, _shootPoint.position, _shootPoint.rotation);
                bullet.GetComponent<Rigidbody>().velocity = direction.normalized * _shotForce;

                _ammoCount--;
                _viewer.DisplayAmmo(_ammoCount);

                _audioController.PlayLaserShotSound();
            }
        }
        else if(_ammoCount == 0)
        {
            _audioController.PlaySound(1);
        }
    }
}