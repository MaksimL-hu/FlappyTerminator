using System;

public class BulletSpawner : GenericSpawner<BulletPool, Bullet>
{
    public event Action BulletHadHit;

    private void OnEnable()
    {
        PoolObjects.BulletHadHit += OnBulletHadHit;
    }

    private void OnDisable()
    {
        PoolObjects.BulletHadHit -= OnBulletHadHit;
    }

    private void OnBulletHadHit()
    {
        BulletHadHit?.Invoke();
    }
}