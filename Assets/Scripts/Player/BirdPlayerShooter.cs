using UnityEngine;

[RequireComponent(typeof(Bird))]
[RequireComponent(typeof(Shooter))]
[RequireComponent (typeof(PlayerInput))]
public class BirdPlayerShooter : MonoBehaviour
{
    [SerializeField] private float _reload;

    private Shooter _shooter;
    private PlayerInput _playerInput;
    private float _lastTimeShoot;

    private void Awake()
    {
        _shooter = GetComponent<Shooter>();
        _playerInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        _lastTimeShoot += Time.deltaTime;
    }

    private void OnEnable()
    {
        _playerInput.RightMouseButtonGottenDown += TryShoot;
    }

    private void OnDisable()
    {
        _playerInput.RightMouseButtonGottenDown -= TryShoot;
    }

    private void TryShoot()
    {
        if (_lastTimeShoot >= _reload)
        {
            _shooter.Shoot();
            _lastTimeShoot = 0;
        }
    }
}