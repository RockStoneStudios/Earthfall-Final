using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] int radius = 5;
    [SerializeField] int damage = 1;

    float damageCooldown = 1.2f; // daño cada 1 segundo
    float timer = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Explode();
    }

    void Update() {
        timer += Time.deltaTime;

        if (timer >= damageCooldown) {
            Explode(); // aplicar daño cada cierto tiempo
            timer = 0f;
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }

    void Explode()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radius);
        Debug.Log("Explode");
        foreach (var hitCollider in hitColliders)
        {
            PlayerHealth playerHealth = hitCollider.GetComponent<PlayerHealth>();
            Debug.Log(playerHealth);
            if (!playerHealth) continue;
            playerHealth.TakeDamage(damage);

            break;
        }
    }

   
}
