using UnityEngine;
using TMPro;

public class CollisionCounter : MonoBehaviour
{
    public TextMeshProUGUI collisionText;
    private int collisionCount = 0;

    private void Start()
    {
        if (collisionText != null)
            collisionText.text = "Зіткнень: 0";
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collisionCount++;
            if (collisionText != null)
                collisionText.text = "Зіткнень: " + collisionCount;
        }
    }
}
