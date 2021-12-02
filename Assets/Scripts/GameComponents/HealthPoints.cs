using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    public int MaxHealth;
    public bool IsAlive { get; private set; }

    public delegate void DeadHandler(GameObject obj);
    public delegate void HealthChangeHandler(int hp);

    public event DeadHandler OnDead;
    public event HealthChangeHandler OnHealthChanged;

    private int _currentHealth;

    private void Awake()
    {
        IsAlive = true;
        _currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        if(IsAlive)
        {
            _currentHealth -= damage;
            OnHealthChanged?.Invoke(_currentHealth);

            if (_currentHealth <= 0)
            {
                IsAlive = false;
                OnDead?.Invoke(gameObject);
            }
        }
    }

    public void AddHealthPoints(int hp)
    {
        if (_currentHealth + hp > MaxHealth)
            _currentHealth += _currentHealth + hp - MaxHealth;
        else if(_currentHealth < MaxHealth)
            _currentHealth += hp;

        OnHealthChanged?.Invoke(_currentHealth);
    }

    public bool IsFullHealthPoints() => _currentHealth == MaxHealth;

    public void Revive()
    {
        _currentHealth = MaxHealth;
        IsAlive = true;
    }
}