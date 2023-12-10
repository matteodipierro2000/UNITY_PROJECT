using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{
    public float velocitaMovimento = 5.0f; // Velocità di movimento del personaggio
    public float sensibilitaMouse = 2.0f; // Sensibilità della rotazione del personaggio
    public float distanzaDaTerreno = 0.1f; // Distanza dal terreno
    public LayerMask layerTerreno; // Layer del terreno

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Movimento del personaggio con le frecce direzionali
        float movimentoOrizzontale = Input.GetAxis("Horizontal");
        float movimentoVerticale = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoOrizzontale, 0.0f, movimentoVerticale);
        rb.MovePosition(rb.position + transform.TransformDirection(movimento) * velocitaMovimento * Time.deltaTime);

        // Rotazione della visuale del personaggio con il mouse
        float rotazioneMouseX = Input.GetAxis("Mouse X") * sensibilitaMouse;
        transform.Rotate(Vector3.up, rotazioneMouseX);

        // Ottieni la normale del terreno sotto il personaggio
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0f, layerTerreno))
        {
            // Posizione desiderata (0.1f sopra il terreno)
            Vector3 desiredPosition = hit.point + hit.normal * distanzaDaTerreno;

            // Imposta la posizione del personaggio alla posizione desiderata
            transform.position = desiredPosition;

            // Rotazione del personaggio in base alla superficie del terreno
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
        }

        // Seguire il personaggio con la camera
        if (Camera.main != null)
        {
            Vector3 nuovaPosizioneCamera = transform.position - transform.forward * 7.0f + Vector3.up * 5.0f;
            Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, nuovaPosizioneCamera, Time.deltaTime * 10.0f);
            Camera.main.transform.LookAt(transform.position + transform.forward * 30.0f);
        }
    }
}