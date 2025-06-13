using StarterAssets;
using UnityEngine;
using UnityEngine.AI;

public class Robot : MonoBehaviour
{
    FirstPersonController player;
    [SerializeField] float chaseRange = 5f;
    NavMeshAgent agent;
    float distanceToTarget = Mathf.Infinity;



    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Start()
    {
        player = FindFirstObjectByType<FirstPersonController>();
        // agent.SetDestination(target.position);


    }


    void Update()
    {
        distanceToTarget = Vector3.Distance(player.transform.position, transform.position);

        if (distanceToTarget <= chaseRange)
        {
            agent.SetDestination(player.transform.position);

        }

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
