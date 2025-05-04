using UnityEngine;

public class EnemyRemover : MonoBehaviour
{
    [SerializeField] private EnemyPool _enemyPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent(out Enemy enemy))
        {
            _enemyPool.PutObject(enemy);
        }
    }
}