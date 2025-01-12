using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown;
    [SerializeField] private Transform firePoint;
    [SerializeField] private GameObject[] fireballs;

    private Animator anim;
    private MovementController playerMovement;
    private CoinManager coinManager;
    private float cooldownTimer = Mathf.Infinity;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        playerMovement = GetComponent<MovementController>();
        coinManager = GetComponent<CoinManager>();
    }

private void Update()
{
    // Adjust the cooldown with a minimum limit
    float adjustedCooldown = Mathf.Max(attackCooldown - coinManager.AttackCooldownReduction, 0.1f);

    if (Input.GetMouseButton(0) && cooldownTimer > adjustedCooldown && playerMovement.canAttack())
        Attack();

    cooldownTimer += Time.deltaTime;
}

    private void Attack()
    {
        anim.SetTrigger("attack");
        cooldownTimer = 0;

        Projectile projectile = fireballs[FindFireball()].GetComponent<Projectile>();


        fireballs[FindFireball()].transform.position = firePoint.position;
        projectile.SetDirection(Mathf.Sign(transform.localScale.x));

        if (coinManager != null)
        {
            float damageMultiplier = coinManager.GetDamageMultiplier();

            projectile.SetDamage(projectile.BaseDamage * damageMultiplier);
        }

    }
    private int FindFireball()
    {
        for (int i = 0; i < fireballs.Length; i++)
        {
            if (!fireballs[i].activeInHierarchy)
                return i;
        }
        return 0;
    }
}