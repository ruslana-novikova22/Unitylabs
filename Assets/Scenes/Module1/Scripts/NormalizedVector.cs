using UnityEngine;

public class VectorCrossProduct : MonoBehaviour
{
    void Start()
    {
        Vector3 a = new Vector3(1, 5, 4);
        Vector3 b = new Vector3(2, -2, -6);

        Vector3 crossProduct = Vector3.Cross(a, b);

        Vector3 normalizedCross = crossProduct.normalized;

        Debug.Log("Нормалізований векторний добуток: " + normalizedCross);
    }
}
