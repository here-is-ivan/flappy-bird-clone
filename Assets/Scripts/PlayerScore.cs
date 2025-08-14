using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    private const string BestScoreKey = "best_socore";
    
    private int _score;
    private int _bestScore;
    
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI bestScoreText;

    private void Start()
    {
        _score = 0;
        _bestScore = PlayerPrefs.GetInt(BestScoreKey);
        UpdateScoresText();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<ScoreTigger>())
        {
            _score++;
            
            if (_score > _bestScore)
            {
                _bestScore = _score;
                SaveBestScore();
            }
            
            UpdateScoresText();
        }
    }
    
    private void SaveBestScore()
    {
        PlayerPrefs.SetInt(BestScoreKey, _bestScore);
        PlayerPrefs.Save();
    }
    
    private void UpdateScoresText()
    {
        scoreText.text = _score.ToString();
        bestScoreText.text = _bestScore.ToString();
    }
}
