using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1; // Value of the coin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            
            CoinManager coinManager = collision.GetComponent<CoinManager>();
            if (coinManager != null)
            {
                coinManager.AddCoins(coinValue);
            }

            
            Destroy(gameObject);
        }
    }
}