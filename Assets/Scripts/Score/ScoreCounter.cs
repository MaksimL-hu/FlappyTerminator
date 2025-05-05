using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private BulletPool _bulletPool;

    private int _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _bulletPool.BulletOnHit += AddScore;
    }

    private void OnDisable()
    {
        _bulletPool.BulletOnHit -= AddScore;
    }

    public void AddScore()
    {
        _score++;
        ScoreChanged?.Invoke(_score);
    }

    public void Reset()
    {
        _score = 0;
        ScoreChanged?.Invoke(_score);
    }
}