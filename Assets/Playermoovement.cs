using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermoovement : MonoBehaviour
{

    public float velocitaMovimento = 5.0f; // Velocità di movimento del personaggio
    public float sensibilitaRotazione = 2.0f; // Sensibilità della rotazione del personaggio
    public Transform mainCamera; // Riferimento alla camera principale

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Otteniamo il riferimento al Rigidbody del personaggio
        if (mainCamera == null)
        {
            mainCamera = Camera.main.transform; // Se il riferimento alla camera non è stato assegnato, usiamo la camera principale
        }
    }

    void Update()
    {
        // Movimento del personaggio in 3D con le frecce direzionali
        float movimentoOrizzontale = Input.GetAxis("Horizontal");
        float movimentoVerticale = Input.GetAxis("Vertical");

        Vector3 movimento = new Vector3(movimentoOrizzontale, 0.0f, movimentoVerticale);
        rb.MovePosition(rb.position + transform.TransformDirection(movimento) * velocitaMovimento * Time.deltaTime);

        // Rotazione del personaggio con il mouse
        float rotazioneMouseX = Input.GetAxis("Mouse X") * sensibilitaRotazione;
        transform.Rotate(Vector3.up, rotazioneMouseX);

        // Seguire il personaggio con la camera
        if (mainCamera != null)
        {
            Vector3 nuovaPosizioneCamera = transform.position - transform.forward * 7.0f + Vector3.up * 5.0f;
            mainCamera.position = Vector3.Lerp(mainCamera.position, nuovaPosizioneCamera, Time.deltaTime * 10.0f);
            mainCamera.LookAt(transform.position + transform.forward * 30.0f);
        }
    }
}