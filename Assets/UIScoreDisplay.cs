using TMPro;
using UnityEngine;

public class UiScoreDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public CoinComponent playerScore;

    void Start()
    {
        playerScore.OnScoreChanged += OnScoreChanged;
        playerScore.OnScoreInitialized += OnScoreInitialized;
    }

    public void OnScoreChanged(float newScore, float amountChanged)
    {
        //Debug.Log("On Score Changed Event");
        scoreText.text = newScore.ToString();
    }

    public void OnScoreInitialized(float newScore)
    {
        scoreText.text = newScore.ToString();
    }
}
