using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [HideInInspector] public Vector3 velocity;
    [HideInInspector] public Vector3 rotation;
    [HideInInspector] public float movementSpeedFactor;

    [Header("Settings")]
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeedHorizontal;
    [SerializeField] private float rotationSpeedVertical;
    [SerializeField] private float cameraRotationLimit;

    private Rigidbody rigidBody;
    private Camera cam;
    private float camCurrentRotationX;

    private void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        cam = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        // Move
        if (velocity != Vector3.zero)
            rigidBody.MovePosition(rigidBody.position + velocity * movementSpeed * movementSpeedFactor * Time.fixedDeltaTime);
    }

    private void Rotate()
    {
        // Rotate Y, separate from X so UP stays UP.
        rigidBody.MoveRotation(rigidBody.rotation * Quaternion.Euler(0, rotation.y * rotationSpeedHorizontal, 0));

        // Rotate X
        if (cam != null)
        {
            camCurrentRotationX -= rotation.x * rotationSpeedVertical;
            camCurrentRotationX = Mathf.Clamp(camCurrentRotationX, -cameraRotationLimit, cameraRotationLimit);
            cam.transform.localEulerAngles = new Vector3(camCurrentRotationX, 0f, 0f);
        }
    }
}
