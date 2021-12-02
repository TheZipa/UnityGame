using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(HealthPoints))]
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public HealthPoints EnemyHealth;

    public int Id { get; private set; }

    [SerializeField] private Animator _animator;
    [SerializeField] private float _attackDelay;
    [SerializeField] private int _scoreForKill;
    private float _nextAttackTime;

    private static int _id;
    private GameObject _player;
    private HealthPoints _playerHealth;
    private Score _playerScore;
    private NavMeshAgent _agent;
    private AudioController _audioController;

    private void Awake()
    {
        EnemyHealth = GetComponent<HealthPoints>();
        _agent = GetComponent<NavMeshAgent>();

        _player = FindObjectOfType<PlayerView>().gameObject;
        _audioController = FindObjectOfType<AudioController>();
        _playerHealth = _player.GetComponent<HealthPoints>();
        _playerScore = _player.GetComponent<Score>();

        Id = _id++;

        EnemyHealth.OnDead += OnEnemyDead;
    }

    private void Update()
    {
        if(_playerHealth.IsAlive == true)
        {
            if (Vector3.Distance(transform.position, _player.transform.position) <= _agent.stoppingDistance && Time.time >= _nextAttackTime)
            {
                _nextAttackTime = Time.time + 1f / _attackDelay;
                AttackPlayer();
            }
        }
    }

    private void FixedUpdate()
    {
        if(_playerHealth.IsAlive == true)
            _agent.SetDestination(_player.transform.position);
    }

    private void OnEnemyDead(GameObject obj)
    {
        _audioController.PlaySound(3);
        _playerScore.AddScore(_scoreForKill);
    }

    public static void ResetId() => _id = 0;

    public void AttackPlayer()
    {
        _playerHealth.TakeDamage(1);
        _animator.SetTrigger("Attack");
    }
}