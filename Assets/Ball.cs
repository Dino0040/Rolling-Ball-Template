using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float maxForce = 10;
    public float maxSpeed = 10;

    Rigidbody rigidbody;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    float GetMainCameraXAngle()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0;
        return Vector3.SignedAngle(Vector3.forward, cameraForward, Vector3.up);
    }

    void FixedUpdate()
    {
        Vector3 axisInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        Vector3 dragForce = -rigidbody.velocity;
        dragForce.y = 0;

        float speedRatioToMax = rigidbody.velocity.magnitude / maxSpeed;

        Quaternion inputRotation = Quaternion.AngleAxis(GetMainCameraXAngle(), Vector3.up);
        rigidbody.AddForce(inputRotation * axisInput * maxForce + (maxForce * speedRatioToMax * dragForce.normalized), ForceMode.Force);
    }
}
