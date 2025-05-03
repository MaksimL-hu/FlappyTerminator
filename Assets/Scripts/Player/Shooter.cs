using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private Bullet _bullet;

    public void Shoot(Quaternion rotation)
    {
        Bullet bullet = Instantiate(_bullet);
        bullet.transform.position = transform.position;
        bullet.transform.rotation = new Quaternion(bullet.transform.rotation.x, bullet.transform.rotation.y, 
            bullet.transform.rotation.z + rotation.z, bullet.transform.rotation.w);
    }
}