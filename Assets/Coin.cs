using UnityEngine;

public class Coin : MonoBehaviour
{
    public float coin = 5 ;
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<CoinComponent>().AddScore(coin);
        Destroy(gameObject);
    }
}
