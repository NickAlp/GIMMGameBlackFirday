using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;  // Speed for moving forward
    public float sideSpeed = 5f;      // Speed for moving left and right
    public float leftRightBoundary = 5f; // Limit how far left and right the player can move
    public float mouseSensitivity = 100f; // Sensitivity for mouse look
    public Transform playerCamera; // Assign the camera in the inspector

    private Rigidbody rb;
    private float xRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Make the cursor invisible
    }

    void Update()
    {
        // Constant forward movement along a fixed direction (global Z axis)
        Vector3 forwardMove = Vector3.forward * forwardSpeed * Time.deltaTime;

        // Left and right movement relative to the global axis (not affected by rotation)
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right
        Vector3 sideMove = Vector3.right * horizontalInput * sideSpeed * Time.deltaTime;

        // Combine forward and side movement to create a movement vector
        Vector3 finalMove = forwardMove + sideMove;

        // Move the player using Rigidbody
        rb.MovePosition(rb.position + finalMove);

        // Restrict left and right movement within boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -leftRightBoundary, leftRightBoundary);
        transform.position = clampedPosition;

        // Mouse look input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Vertical rotation (up and down) for the camera only
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent over-rotation
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal rotation (left and right) applied to the player body for rotating the view
        transform.Rotate(Vector3.up * mouseX);
    }
}


