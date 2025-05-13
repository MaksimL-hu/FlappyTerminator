using System.Collections;
using UnityEngine;

public class EnemySpawner : GenericEnemySpawner<EnemyPool, Enemy>
{
    [SerializeField] private float _delay;
    [SerializeField] private float _lowerBound;
    [SerializeField] private float _upperBound;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        var wait = new WaitForSeconds(_delay);

        while (enabled)
        {
            Spawn();
            yield return wait;
        }
    }

    protected override Enemy Spawn()
    {
        float spawnPositionY = Random.Range(_upperBound, _lowerBound);
        Vector3 spawnPoint = new Vector3(transform.position.x, spawnPositionY, transform.localPosition.z);

        Enemy enemy = base.Spawn();
        enemy.transform.position = spawnPoint;

        return enemy;
    }
}