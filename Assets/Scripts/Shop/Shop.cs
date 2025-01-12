using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private CoinManager coinManager; // Reference to CoinManager
    [SerializeField] private int damageUpgradeCost = 10; // Cost for damage multiplier upgrade
    [SerializeField] private float damageMultiplierIncrease = 0.5f; // Amount to increase damage multiplier
    [SerializeField] private int cooldownReductionCost = 15; // Cost for cooldown reduction
    [SerializeField] private float cooldownReduction = 0.2f; // Amount to reduce cooldown

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