using UnityEngine;

public class Finish : MonoBehaviour
{
    public Color finishColor = Color.green; // Êîë³ð ô³í³øó

    private void Start()
    {
        GetComponent<Renderer>().material.color = finishColor;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GlobalStorage.Instance != null) 
        {
            GlobalStorage.Instance.OnLevelComplete();
        }
    }
}
