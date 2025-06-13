using UnityEngine;
using UnityEngine.AI;

public class FixNavMeshPosition : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            // Fuerza la posición al inicio
            agent.Warp(transform.position);
            // Desactiva el movimiento automático hasta que lo configures
            agent.isStopped = true;
            Debug.Log("NavMeshAgent posicionado en: " + transform.position);
        }
        else
        {
            Debug.LogError("NavMeshAgent no encontrado en este GameObject.");
        }
    }

    void Update()
    {
        // Opcional: Sincroniza la posición en cada frame si sigue desalineándose
        if (agent != null && agent.transform.position != transform.position)
        {
            agent.Warp(transform.position);
        }
    }
}
