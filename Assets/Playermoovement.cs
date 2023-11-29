using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 3.0f;

    private Rigidbody rb;
    private Camera playerCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Movimento del personaggio tramite frecce direzionali
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Effettua il movimento solo se non c'è collisione in avanti
        if (!IsCollidingForward())
        {
            rb.MovePosition(transform.position + transform.TransformDirection(movement));
        }

        // Rotazione della visuale con il mouse
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        transform.Rotate(Vector3.up * mouseX);

        // Movimento della telecamera per seguire il personaggio
        Vector3 cameraFollowPosition = transform.position - transform.forward * 5.0f + Vector3.up * 2.0f;
        playerCamera.transform.position = Vector3.Lerp(playerCamera.transform.position, cameraFollowPosition, Time.deltaTime * 10.0f);
        playerCamera.transform.LookAt(transform.position + transform.forward * 10.0f);
    }

    bool IsCollidingForward()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f))
        {
            // Controlla se la collisione è con un oggetto fisico
            if (hit.collider.gameObject.GetComponent<Rigidbody>() != null)
            {
                return true;
            }
        }
        return false;
    }
} 