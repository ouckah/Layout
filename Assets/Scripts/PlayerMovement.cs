using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float lookSpeedX = 2f;
    public float lookSpeedY = 2f;

    private CharacterController characterController;
    private Camera playerCamera;
    private float rotationX = 0f;

    // Start is called once before the first execution of Update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        if (characterController == null)
        {
            Debug.LogError("CharacterController is missing from the player object!");
        }

        playerCamera = Camera.main;
        if (playerCamera == null)
        {
            Debug.LogError("Main Camera is missing!");
        }

        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center
        Cursor.visible = false; // Hide the cursor
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        LookAround();
    }

    void MovePlayer()
    {
        // Get the input values
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Create movement vector
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        // Move the player using the CharacterController
        characterController.Move(move * moveSpeed * Time.deltaTime);

        // Debugging info
        Debug.Log($"Move: {move}, Speed: {moveSpeed}");
    }

    void LookAround()
    {
        float mouseX = Input.GetAxis("Mouse X") * lookSpeedX;
        float mouseY = Input.GetAxis("Mouse Y") * lookSpeedY;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        // Apply the camera rotation
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);

        // Rotate the player object (body)
        transform.Rotate(Vector3.up * mouseX);

        // Debugging info
        Debug.Log($"Mouse X: {mouseX}, Mouse Y: {mouseY}");
    }
}