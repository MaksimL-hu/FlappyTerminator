using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;
    [SerializeField] private float _additionalRotation;

    public void Shoot()
    {
        Bullet bullet = _bulletSpawner.GetBullet();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y,
            transform.rotation.eulerAngles.z + _additionalRotation);
    }
}