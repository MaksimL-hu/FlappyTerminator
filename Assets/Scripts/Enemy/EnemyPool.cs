using UnityEngine;
using System.Collections.Generic;

public class EnemyPool : MonoBehaviour
{
    [SerializeField] private Transform _container;
    [SerializeField] private List<Enemy> _enemies;

    private Queue<Enemy> _pool;

    private void Start()
    {
        _pool = new Queue<Enemy>();

        for (int i = 0; i < _enemies.Count; i++)
        {
            _pool.Enqueue(InstantiateEnemy(i));
        }

        _pool = QueueExtensions.Shuffle(_pool);
    }

    private Enemy InstantiateEnemy(int index)
    {
        Enemy enemy = Instantiate(_enemies[index]);
        enemy.transform.parent = _container;
        enemy.gameObject.SetActive(false);

        return enemy;
    }

    public Enemy GetObject()
    {
        if (_pool.Count == 0)
        {
            return InstantiateEnemy(UnityEngine.Random.Range(0, _enemies.Count));
        }

        return _pool.Dequeue();
    }

    public void PutObject(Enemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.gameObject.SetActive(false);
    }
}