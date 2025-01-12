using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    [SerializeField] private int CoinValue;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<CoinManager>().AddCoins(CoinValue);
            gameObject.SetActive(false);
        }
    }
}