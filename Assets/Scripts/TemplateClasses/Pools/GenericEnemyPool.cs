using System.Collections.Generic;
using UnityEngine;

public class GenericEnemyPool<TEnemy> : MonoBehaviour where TEnemy : Enemy
{
    [SerializeField] protected Transform Container;
    [SerializeField] protected List<TEnemy> PrefabEnemies;

    private Queue<TEnemy> _pool;
    private List<TEnemy> _enemies;

    protected virtual void Awake()
    {
        _pool = new Queue<TEnemy>();
        _enemies = new List<TEnemy>();

        for (int i = 0; i < PrefabEnemies.Count; i++)
        {
            _pool.Enqueue(InstantiateEnemy(i));
        }

        _pool = QueueExtensions.Shuffle(_pool);
    }

    protected virtual TEnemy InstantiateEnemy(int index)
    {
        TEnemy enemy = Instantiate(PrefabEnemies[index]);
        enemy.transform.parent = Container;
        enemy.gameObject.SetActive(false);
        _enemies.Add(enemy);

        return enemy;
    }

    protected virtual void DestroyEnemy(TEnemy enemy)
    {
        Destroy(enemy.gameObject);
    }

    public virtual TEnemy GetObject()
    {
        if (_pool.Count == 0)
        {
            return InstantiateEnemy(UnityEngine.Random.Range(0, PrefabEnemies.Count));
        }

        return _pool.Dequeue();
    }

    public virtual void PutObject(TEnemy enemy)
    {
        _pool.Enqueue(enemy);
        enemy.Reset();
        enemy.gameObject.SetActive(false);
    }

    public virtual void Reset()
    {
        foreach (TEnemy enemy in _enemies)
        {
            if (enemy.gameObject.activeSelf)
            {
                PutObject(enemy);
            }
        }
    }
}