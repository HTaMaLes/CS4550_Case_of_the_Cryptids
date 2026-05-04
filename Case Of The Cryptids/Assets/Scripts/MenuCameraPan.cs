using UnityEngine;

public class MenuCameraPan : MonoBehaviour
{
    [Header("Forward Movement")]
    public float moveSpeed = 0.5f;

    [Header("Side to Side Pan")]
    public float panSpeed = 0.5f;
    public float panDistance = 3f;

    [Header("Rotation")]
    public float rotateSpeed = 5f;

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        // Forward movement
        Vector3 forwardMove = transform.forward * moveSpeed * Time.deltaTime;

        // Side-to-side motion (smooth sine wave)
        float sideOffset = Mathf.Sin(Time.time * panSpeed) * panDistance;
        Vector3 sideMove = transform.right * sideOffset;

        // Apply movement
        transform.position = startPos + sideMove + forwardMove * Time.time;

        // Gentle rotation
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}