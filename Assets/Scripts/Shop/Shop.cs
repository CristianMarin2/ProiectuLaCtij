using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager; // Referința către CoinManager
    [SerializeField] private int damageUpgradeCost = 10; // Cost pentru Damage Multiplier
    [SerializeField] private float damageMultiplierIncrease = 1f; // Creștere Damage Multiplier
    [SerializeField] private int cooldownReductionCost = 15; // Cost pentru Cooldown Reduction
    [SerializeField] private float cooldownReduction = 0.05f; // Reducere Cooldown

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) // Tasta "1" pentru Upgrade Damage
        {
            BuyDamageMultiplier();
        }
        else if (Input.GetKeyDown(KeyCode.M)) // Tasta "2" pentru Reduce Cooldown
        {
            BuyCooldownReduction();
        }
    }

    public void BuyDamageMultiplier()
    {
        if (coinManager != null && coinManager.SpendCoins(damageUpgradeCost))
        {
            coinManager.UpgradeDamageMultiplier(damageMultiplierIncrease);
            Debug.Log("Damage Multiplier Upgraded!");
        }
        else
        {
            Debug.Log("Not enough coins to upgrade damage multiplier!");
        }
    }

    public void BuyCooldownReduction()
    {
        if (coinManager != null && coinManager.SpendCoins(cooldownReductionCost))
        {
            coinManager.ReduceAttackCooldown(cooldownReduction);
            Debug.Log("Attack Cooldown Reduced!");
        }
        else
        {
            Debug.Log("Not enough coins to reduce attack cooldown!");
        }
    }
}