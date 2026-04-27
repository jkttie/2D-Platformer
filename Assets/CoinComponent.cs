using UnityEngine;

public class CoinComponent : MonoBehaviour
{
    private float baseScore = 0;
    private float score;

    public delegate void ScoreChangedHandler(float newScore, float amountChanged);
    public event ScoreChangedHandler OnScoreChanged;

    public delegate void ScoreInitializer(float newScore);
    public event ScoreInitializer OnScoreInitialized;
    void Start()
    {
        score = baseScore;
        OnScoreInitialized?.Invoke(score);
    }
    void Update()
    {
        
    }
    public void AddScore(float coin)
    {
        baseScore += coin;
        OnScoreChanged?.Invoke(baseScore, coin);
        //Debug.Log(score);
    }
}
