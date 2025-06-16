using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int radius = 5;
    [SerializeField] int damage = 3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Explode();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);

        foreach (var hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();

            if (!playerHealth) continue;
            playerHealth.TakeDamage(damage);

            break;
        }
    }

   
}
