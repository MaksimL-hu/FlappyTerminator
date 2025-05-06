using System;
using UnityEngine;
using UnityEngine.Pool;

public class BulletPool : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;
    [SerializeField] private Transform _container;

    private ObjectPool<Bullet> _pool;

    public event Action BulletHadHit;

    private void Awake()
    {
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
        foreach (Bullet bullet in _container.GetComponentsInChildren<Bullet>())
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
        Destroy(bullet.gameObject);
    }

    private void BulletHit(Bullet bullet)
    {
        BulletHadHit?.Invoke();
        ReleaseBullet(bullet);
    }
}