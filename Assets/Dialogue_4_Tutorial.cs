using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_4_Tutorial : MonoBehaviour
{// Metodo per avviare la finestra di dialogo
    void Start()
    {
        // Avvia la coroutine per far comparire e scomparire la finestra
        StartCoroutine(GestisciFinestraDiDialogo());
    }

    // Coroutine per gestire la comparsa e la scomparsa della finestra di dialogo
    IEnumerator GestisciFinestraDiDialogo()
    {
        // Aspetta 10 secondi prima di far comparire la finestra
        yield return new WaitForSeconds(25f);

        // Attiva la finestra di dialogo
        gameObject.SetActive(true);

        // Aspetta altri 10 secondi prima di far scomparire la finestra
        yield return new WaitForSeconds(5f);

        // Disattiva la finestra di dialogo
        gameObject.SetActive(false);
    }
 }
