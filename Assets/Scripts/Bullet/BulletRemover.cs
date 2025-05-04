using UnityEngine;

public class BulletRemover : MonoBehaviour
{
    [SerializeField] private BulletPool _playerBulletPool;
    [SerializeField] private BulletPool _enemyBulletPool;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerBullet playerBullet))
        {
            _playerBulletPool.ReleaseBullet(playerBullet);
        }
        else if(collision.TryGetComponent(out EnemyBullet enemyBullet))
        {
            _enemyBulletPool.ReleaseBullet(enemyBullet);
        }
    }
}