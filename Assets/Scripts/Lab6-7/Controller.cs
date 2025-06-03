using UnityEngine;
using UnityEngine.AI;

public class Controller : MonoBehaviour
{
    private NavMeshAgent agent;

    public GameObject bulletPrefab;
    public float bulletHeight = 1f;
    public float bulletSpeed = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Ліва кнопка миші – рух
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                agent.SetDestination(hit.point);
            }
        }

        // Права кнопка миші – постріл
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Enemy"))
                {
                    Vector3 spawnPos = transform.position + Vector3.up * bulletHeight;
                    GameObject bullet = Instantiate(bulletPrefab, spawnPos, Quaternion.identity);

                    Vector3 direction = (hit.point - spawnPos).normalized;
                    bullet.GetComponent<Rigidbody>().linearVelocity = direction * bulletSpeed;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Road"))
            agent.speed = 5f;
        else if (other.CompareTag("Field"))
            agent.speed = 3f;
        else if (other.CompareTag("Swamp"))
            agent.speed = 1.5f;
    }
}
