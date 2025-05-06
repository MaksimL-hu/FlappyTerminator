using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    [Header("Pools")]
    [SerializeField] private EnemyPool _enemyPool;
    [SerializeField] private BulletPool _playerBulletPool;
    [SerializeField] private BulletPool _enemyBulletPool;

    [Header("Screens")]
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private EndGameScreen _endGameScreen;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
        _bird.GameOvered += OnGameOver;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
        _bird.GameOvered -= OnGameOver;
    }

    private void OnGameOver()
    {
        Time.timeScale = 0;
        _endGameScreen.Open();
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        RestartGame();
    }

    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
    }

    private void RestartGame()
    {
        StartGame();
        _bird.Reset();
        _enemyPool.Reset();
        _playerBulletPool.Reset();
        _enemyBulletPool.Reset();
    }
}