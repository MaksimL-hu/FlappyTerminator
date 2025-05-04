using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action<Bullet> OnHit;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    protected void Hit()
    {
        OnHit?.Invoke(this);
    }
}