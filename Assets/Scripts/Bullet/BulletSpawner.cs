using System;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;

    public event Action BulletHadHit;

    private void OnEnable()
    {
        _bulletPool.BulletHadHit += OnBulletHadHit;
    }

    private void OnDisable()
    {
        _bulletPool.BulletHadHit -= OnBulletHadHit;
    }

    private void OnBulletHadHit()
    {
        BulletHadHit?.Invoke();
    }

    public Bullet GetBullet()
    {
        return _bulletPool.GetBullet();
    }

    public void Reset()
    {
        _bulletPool.Reset();
    }
}