using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int coinValue = 1; // Value of the coin

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player collects the coin
        if (collision.CompareTag("Player"))
        {
            // Access the PlayerStats component and add coins
            CoinManager coinManager = collision.GetComponent<CoinManager>();
            if (coinManager != null)
            {
                coinManager.AddCoins(coinValue);
            }

            // Destroy the coin after it's collected
            Destroy(gameObject);
        }
    }
}