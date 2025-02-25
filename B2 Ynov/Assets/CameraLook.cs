using UnityEngine;

public class CameraLook : MonoBehaviour
{
    public float sensitivity = 2f; // Sensibilit� de la cam�ra
    private float rotationX = 0f;

    void Update()
    {
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // Rotation haut/bas
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Emp�che de trop tourner

        transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);
    }
}
