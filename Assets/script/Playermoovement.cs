using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotationSpeed = 3.0f;
    public float distanceFromGround = 1.0f; // Distanza desiderata dal terreno
    public LayerMask groundLayer; // LayerMask per il terreno

    private Rigidbody rb;
    private Camera playerCamera;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;

        // Assegna il Layer "Terrain" al LayerMask
        groundLayer = LayerMask.GetMask("Terrain");
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

        // Adatta il personaggio al terreno
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, distanceFromGround + 0.1f, groundLayer))
        {
            Vector3 targetPosition = hit.point + Vector3.up * distanceFromGround;
            rb.MovePosition(targetPosition);

            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            rb.MoveRotation(Quaternion.Slerp(transform.rotation, targetRotation, 10.0f * Time.deltaTime));
        }
    }

    bool IsCollidingForward()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 0.5f))
        {
            if (hit.collider.gameObject.layer != LayerMask.NameToLayer("Terrain"))
            {
                return true;
            }
        }
        return false;
    }
}