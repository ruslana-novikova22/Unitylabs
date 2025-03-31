using UnityEngine;

public class Coin : MonoBehaviour
{
    public Color coinColor = Color.yellow; // Колір монети

    private void Start()
    {
        GetComponent<Renderer>().material.color = coinColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GlobalStorage.Instance.CollectCoin();
            Destroy(gameObject);
        }
    }
}
