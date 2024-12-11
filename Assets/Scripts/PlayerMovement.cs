using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float sideSpeed = 5f; // Speed for moving left and right
    public float leftRightBoundary = 5f; // Limit how far left and right the player can move
    public float upDownBoundary = 5f; // Limit how far left and right the player can move
    public float mouseSensitivity = 100f; // Sensitivity for mouse look
    public Transform playerCamera; // Assign the camera in the inspector

    private Rigidbody rb;
    private float xRotation = 0f; // Vertical rotation (up and down)
    private float yRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Make the cursor invisible
    }

    void Update()
    {
        // Left and right movement input
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right
        Vector3 sideMove = Vector3.right * horizontalInput * sideSpeed * Time.deltaTime;

        float verticalInput = Input.GetAxis("Vertical"); // A/D or Left/Right
        Vector3 upMove = Vector3.right * horizontalInput * sideSpeed * Time.deltaTime;

        // Apply left and right movement
        rb.MovePosition(rb.position + sideMove);

        // Restrict left and right movement within boundaries
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, -leftRightBoundary, leftRightBoundary);
        transform.position = clampedPosition;

        // Mouse look input
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;

        // Calculate vertical rotation (up and down) for the camera
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Prevent over-rotation

        yRotation -= mouseX;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        // Apply rotation to the camera for looking up and down
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.localRotation = Quaternion.Euler(0f, -yRotation, 0f);

    }
}


