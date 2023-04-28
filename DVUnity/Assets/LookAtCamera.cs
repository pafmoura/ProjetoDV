using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    public Camera mainCamera;

    void Start()
    {
        
        
    }

    void LateUpdate()
    {
        // Rotate the UI to face the camera
        transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
    }
}
