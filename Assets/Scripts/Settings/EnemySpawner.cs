using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _enemySpawnPoints;
    [SerializeField] GameObject[] _enemyPrefabs;

    [SerializeField] private int _maxEnemiesOnScene;
    [SerializeField] private int _maxEnemies;

    private int _enemySpawnStep;
    private List<Enemy> _enemies;

    private void Awake()
    {
        int prefabsLength = _enemyPrefabs.Length;
        int spawnPointLength = _enemySpawnPoints.Length;

        _enemies = new List<Enemy>();
        _enemySpawnStep = _maxEnemiesOnScene - 1;
        Enemy.ResetId();

        for (int i = 0; i < _maxEnemies; i++)
        {
            GameObject newEnemy = Instantiate(_enemyPrefabs[Random.Range(0, prefabsLength)], _enemySpawnPoints[Random.Range(0, spawnPointLength)].position, Quaternion.identity);

            _enemies.Add(newEnemy.GetComponent<Enemy>());
            _enemies[i].EnemyHealth.OnDead += OnEnemyDead;

            if(i >= _maxEnemiesOnScene)
            {
                _enemies[i].gameObject.SetActive(false);
            }
        }
    }

    private void OnEnemyDead(GameObject enemy)
    {
        int enemyIndex = enemy.GetComponent<Enemy>().Id;

        _enemies[enemyIndex].gameObject.SetActive(false);
        _enemies[enemyIndex].EnemyHealth.Revive();
        _enemies[enemyIndex].transform.position = _enemySpawnPoints[Random.Range(0, _enemySpawnPoints.Length)].position;

        if (++_enemySpawnStep == _maxEnemies)
            _enemySpawnStep = 0;

        _enemies[_enemySpawnStep].gameObject.SetActive(true);
    }
}