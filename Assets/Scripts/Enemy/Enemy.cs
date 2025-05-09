using System;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _maxReload;
    [SerializeField] private float _minReload;

    private Shooter _shooter;
    private float _reloadTime;
    private float _timeAfterLastAttack;

    public event Action<Enemy> Died;

    private void Start()
    {
        _shooter = GetComponent<Shooter>();
        _reloadTime = UnityEngine.Random.Range(_maxReload, _maxReload);
    }

    private void Update()
    {
        _timeAfterLastAttack += Time.deltaTime;

        if (_timeAfterLastAttack >= _reloadTime)
        {
            _shooter.Shoot();
            _timeAfterLastAttack = 0;
        }
    }

    public void Die()
    {
        Died?.Invoke(this);
    }
}