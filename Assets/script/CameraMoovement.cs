using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float sensitivity = 2.0f;
    private Vector3 lastMousePosition;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        // Movimento della camera
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

        // Rotazione della camera
        Vector3 mouseDelta = Input.mousePosition - lastMousePosition;
        transform.Rotate(Vector3.up * mouseDelta.x * sensitivity);
        transform.Rotate(Vector3.left * mouseDelta.y * sensitivity);

        lastMousePosition = Input.mousePosition;
    }
}