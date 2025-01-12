using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
 [SerializeField] private int Coins;
    public float DamageMultiplier { get; private set; } = 1f;
    public float AttackCooldownReduction { get; private set; } = 0f;

    public void AddCoins(int amount)
    {
        Coins += amount;
        Debug.Log("Coins: " + Coins);
    }

    public bool SpendCoins(int amount)
    {
        if (Coins >= amount)
        {
            Coins -= amount;
            return true;
        }
        return false;
    }

    public void UpgradeDamageMultiplier(float increaseAmount)
    {
        DamageMultiplier += increaseAmount;
        Debug.Log("Damage Multiplier: " + DamageMultiplier);
    }

    public float GetDamageMultiplier(){
        return DamageMultiplier;
    }

    public void ReduceAttackCooldown(float reductionAmount)
    {
        AttackCooldownReduction += reductionAmount;
        Debug.Log("Attack Cooldown Reduction: " + AttackCooldownReduction);
    }
}
