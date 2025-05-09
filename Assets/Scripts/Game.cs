using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;

    [Header("Spawners")]
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletSpawner _playerBulletSpawner;
    [SerializeField] private BulletSpawner _enemyBulletSpawner;

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
        _bird.Reset();
        _enemySpawner.Reset();
        _playerBulletSpawner.Reset();
        _enemyBulletSpawner.Reset();
        StartGame();
    }
}