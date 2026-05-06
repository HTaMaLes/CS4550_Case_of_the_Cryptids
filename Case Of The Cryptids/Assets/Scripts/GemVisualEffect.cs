using UnityEngine;

public class GemVisualEffect : MonoBehaviour
{
    public float rotationSpeed = 60f;
    public float floatSpeed = 2f;
    public float floatHeight = 0.15f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        transform.Rotate(0f, rotationSpeed * Time.deltaTime, 0f);

        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);
    }
}