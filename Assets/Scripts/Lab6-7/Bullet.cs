using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    private Vector3 direction;

    public GameObject hitEffectPrefab;

    public void SetDirection(Vector3 dir)
    {
        direction = dir.normalized;
    }

    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("FieldEnemy") || other.CompareTag("SwampEnemy"))
        {
            if (hitEffectPrefab != null)
            {
                GameObject fx = Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
                Destroy(fx, 2f);
            }

            Destroy(other.gameObject); // Знищити ворога
            Destroy(gameObject);       // Знищити снаряд
        }
    }

}
