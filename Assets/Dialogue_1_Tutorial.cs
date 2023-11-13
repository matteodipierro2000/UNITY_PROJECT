using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue_1_Tutorial : MonoBehaviour
{
    // Metodo per avviare la finestra di dialogo
    void Start()
    {
        // Avvia la coroutine per far sparire la finestra dopo 20 secondi
        StartCoroutine(NascondiDopoTempo(6f));
    }

    // Coroutine per nascondere la finestra dopo un certo periodo di tempo
    IEnumerator NascondiDopoTempo(float tempo)
    {
        // Aspetta per il periodo di tempo specificato
        yield return new WaitForSeconds(tempo);

        // Rendi la finestra di dialogo non attiva (disabilita)
        gameObject.SetActive(false);
    }
}



