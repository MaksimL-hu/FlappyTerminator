using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _container;

    private ObjectPool<Bullet> _pool;
    private List<Bullet> _bullets;

    public event Action BulletHadHit;

    private void Awake()
    {
        _bullets = new List<Bullet>();
        _pool = new ObjectPool<Bullet>(
            createFunc: () => InstantiateBullet(),
            actionOnRelease: (bullet) => OnActionRelease(bullet),
            actionOnDestroy: (bullet) => DestroyObject(bullet));
    }

    public void ReleaseBullet(Bullet bullet)
    {
        _pool.Release(bullet);
    }

    public void Reset()
    {
        foreach (Bullet bullet in _bullets)
        {
            if (bullet.gameObject.activeSelf)
            {
                ReleaseBullet(bullet);
            }
        }
    }

    public Bullet GetBullet()
    {
        return _pool.Get();
    }

    private Bullet InstantiateBullet()
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.transform.parent = _container;
        bullet.HadHit += BulletHit;
        bullet.Removing += ReleaseBullet;
        _bullets.Add(bullet);

        return bullet;
    }

    private void OnActionRelease(Bullet bullet)
    {
        bullet.transform.rotation = Quaternion.Euler(Vector3.zero);
        bullet.gameObject.SetActive(false);
    }

    private void DestroyObject(Bullet bullet)
    {
        bullet.HadHit -= BulletHit;
        bullet.Removing -= ReleaseBullet;
        Destroy(bullet.gameObject);
    }

    private void BulletHit(Bullet bullet)
    {
        BulletHadHit?.Invoke();
        ReleaseBullet(bullet);
    }
}