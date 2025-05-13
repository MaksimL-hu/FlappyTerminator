using System;
using UnityEngine;

[RequireComponent(typeof(Shooter))]
public class Enemy : MonoBehaviour, IInteractable
{
    [SerializeField] private float _reloadTime;

    private Shooter _shooter;
    private float _timeAfterLastAttack;

    public event Action<Enemy> Died;

    private void Start()
    {
        _shooter = GetComponent<Shooter>();
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

    public void Reset()
    {
        _timeAfterLastAttack = 0;
    }

    public void Die()
    {
        Reset();
        Died?.Invoke(this);
    }
}