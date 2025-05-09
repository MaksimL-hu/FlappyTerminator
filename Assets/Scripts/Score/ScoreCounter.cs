using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private BulletSpawner _bulletSpawner;

    private int _score;

    public event Action<int> ScoreChanged;

    private void OnEnable()
    {
        _bulletSpawner.BulletHadHit += AddScore;
    }

    private void OnDisable()
    {
        _bulletSpawner.BulletHadHit -= AddScore;
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