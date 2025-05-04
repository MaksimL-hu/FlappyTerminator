using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private TMP_Text _score;
    [SerializeField] private string _additionalText;

    private void OnEnable()
    {
        _scoreCounter.ScoreChanged += OnScoreChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ScoreChanged -= OnScoreChanged;
    }

    private void OnScoreChanged(int score)
    {
        _score.text = _additionalText + score.ToString();
    }
}
