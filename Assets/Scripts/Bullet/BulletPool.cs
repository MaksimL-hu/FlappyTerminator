using System;
using UnityEngine;

public class BulletPool : GenericPool<Bullet>
{
    public event Action BulletHadHit;

    private void OnBulletHadHit(Bullet bullet)
    {
        BulletHadHit?.Invoke();
        ReleaseObject(bullet);
    }

    protected override Bullet InstantiateObject()
    {
        Bullet bullet = base.InstantiateObject();
        bullet.HadHit += OnBulletHadHit;
        bullet.Removing += ReleaseObject;

        return bullet;
    }

    protected override void OnActionRelease(Bullet bullet)
    {
        bullet.transform.rotation = Quaternion.Euler(Vector3.zero);
        base.OnActionRelease(bullet);
    }

    protected override void DestroyObject(Bullet bullet)
    {
        bullet.HadHit -= OnBulletHadHit;
        bullet.Removing -= ReleaseObject;
        base.DestroyObject(bullet);
    }
}