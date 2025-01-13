using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float baseDamage;

    private float direction;
    private bool hit;
    private float lifetime;
    private float currentDamage;

    private Animator anim;
    private BoxCollider2D boxCollider;

    public float BaseDamage => baseDamage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);

        lifetime += Time.deltaTime;
        if (lifetime > 5) gameObject.SetActive(false); // Deactivate projectile after 5 seconds
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (hit) return;

        hit = true;
        boxCollider.enabled = false;

        // Trigger explosion animation
        if (anim != null)
        {
            anim.SetTrigger("explode");
        }

        // Check if the object is an enemy
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(currentDamage); // Apply damage to the enemy
            }
        }
    }

    public void SetDirection(float _direction)
    {
        lifetime = 0;
        direction = _direction;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        // Flip the projectile if necessary
        float localScaleX = transform.localScale.x;
        if (Mathf.Sign(localScaleX) != _direction)
            localScaleX = -localScaleX;

        transform.localScale = new Vector3(localScaleX, transform.localScale.y, transform.localScale.z);
    }

    public void SetDamage(float damage)
    {
        currentDamage = damage; // Assign dynamic damage
    }

    private void Deactivate()
    {
        gameObject.SetActive(false); // Deactivate the projectile
    }
}
