using UnityEngine;

public class Projectil : MonoBehaviour
{
    [SerializeField] float speed = 30f;
    [SerializeField] GameObject projectileHitVfx;
    int damage;
    Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    public void Init(int damage)
    {
        this.damage = damage;
    }

    void OnTriggerEnter(Collider other)
    {
        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth?.TakeDamage(damage);
        Instantiate(projectileHitVfx, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

}
