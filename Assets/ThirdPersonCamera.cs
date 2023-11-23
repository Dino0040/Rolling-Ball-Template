using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float sensitivity = 2;
    public float tiltAngle = 6;

    float yCameraAngle;
    float xCameraAngle;

    void Update()
    {
        Vector2 cameraInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        yCameraAngle -= cameraInput.y * sensitivity;
        yCameraAngle = Mathf.Clamp(yCameraAngle, -10, 85);
        xCameraAngle += cameraInput.x * sensitivity;
        xCameraAngle %= 360;

        Vector3 axisInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        transform.rotation = Quaternion.Euler(-axisInput.z * tiltAngle + yCameraAngle,
            xCameraAngle,
            0);
        Vector3 flatForward = new Vector3(transform.forward.x, 0, transform.forward.z);
        transform.RotateAround(transform.position, flatForward, axisInput.x * tiltAngle);
    }
}
