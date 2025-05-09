using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;

    public event Action<Bullet> Removing;
    public event Action<Bullet> HadHit;

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    public void Hit()
    {
        HadHit?.Invoke(this);
    }

    public void Remove()
    {
        Removing?.Invoke(this);
    }
}