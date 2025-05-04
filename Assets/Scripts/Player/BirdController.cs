using UnityEngine;

[RequireComponent(typeof(Bird))]
[RequireComponent(typeof(Shooter))]
public class BirdController : MonoBehaviour
{
    [SerializeField] private float _reload;

    private Shooter _shooter;
    private float _lastTimeShoot;

    private void Start()
    {
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        _lastTimeShoot += Time.deltaTime;

        if (Input.GetMouseButtonDown(0) && _lastTimeShoot >= _reload)
        {
            _shooter.Shoot();
            _lastTimeShoot = 0;
        }
    }
}