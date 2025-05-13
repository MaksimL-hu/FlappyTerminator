using UnityEngine;

public class GenericEnemySpawner<TEnemyPool, TEnemy> : MonoBehaviour
    where TEnemyPool : GenericEnemyPool<TEnemy>
    where TEnemy : Enemy
{
    [SerializeField] protected TEnemyPool Pool;

    protected virtual TEnemy Spawn()
    {
        TEnemy enemy = Pool.GetObject();
        enemy.gameObject.SetActive(true);

        return enemy;
    }

    public virtual void Reset()
    {
        Pool.Reset();
    }
}
