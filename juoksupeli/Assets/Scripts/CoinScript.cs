using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float rotationSpeed = 50.0f;

    void Update()
    {
        // Rotate the coin around the Y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
