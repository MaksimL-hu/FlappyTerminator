using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private List<Enemy> _prefabEnemies;

    private Queue<Enemy> _pool;
    private List<Enemy> _enemies;

    private void Awake()
    {
        _pool = new Queue<Enemy>();
        _enemies = new List<Enemy>();

        for (int i = 0; i < _prefabEnemies.Count; i++)
        {
            _pool.Enqueue(InstantiateEnemy(i));
        }

        _pool = QueueExtensions.Shuffle(_pool);
    }

    public Enemy GetObject()
    {
        if (_pool.Count == 0)
        {
            return InstantiateEnemy(UnityEngine.Random.Range(0, _prefabEnemies.Count));
        }

        return _pool.Dequeue();
    }

    public void PutObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }

    public void Reset()
    {
        foreach (Enemy enemy in _enemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                PutObject(enemy);
            }
        }
    }

    private Enemy InstantiateEnemy(int index)
    {
        Enemy enemy = Instantiate(_prefabEnemies[index]);
        enemy.transform.parent = _container;
        enemy.gameObject.SetActive(false);
        _enemies.Add(enemy);
        enemy.Died += PutObject;

        return enemy;
    }

    private void DestroyEnemy(Enemy enemy)
    {
        enemy.Died -= PutObject;
        Destroy(enemy.gameObject);
    }
}