using UnityEngine;
using UnityEngine.AI;

public class EnemyZoneLimiter : MonoBehaviour
{
    private string allowedZoneTag;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (CompareTag("FieldEnemy"))
            allowedZoneTag = "Field";
        else if (CompareTag("SwampEnemy"))
            allowedZoneTag = "Swamp";
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Field") && allowedZoneTag != "Field")
        {
            agent.isStopped = true;
        }
        else if (other.CompareTag("Swamp") && allowedZoneTag != "Swamp")
        {
            agent.isStopped = true;
        }
        else
        {
            agent.isStopped = false;
        }
    }
}
