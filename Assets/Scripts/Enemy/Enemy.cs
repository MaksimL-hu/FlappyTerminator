using System;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _maxReload;
    [SerializeField] private float _minReload;

    private Shooter _shooter;
    private float _reloadTime;
    private float _lastTimeAttack;

    public event Action<Enemy> Died;

    private void Start()
    {
        _shooter = GetComponent<Shooter>();
        _reloadTime = UnityEngine.Random.Range(_maxReload, _maxReload);
    }

    private void Update()
    {
        _lastTimeAttack += Time.deltaTime;

        if (_lastTimeAttack >= _reloadTime)
        {
            _shooter.Shoot();
            _lastTimeAttack = 0;
        }
    }

    public void Die()
    {
        Died?.Invoke(this);
    }
}