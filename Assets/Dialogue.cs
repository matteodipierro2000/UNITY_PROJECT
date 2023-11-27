using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
      public GameObject[] dialogWindows; // Array contenente le finestre di dialogo
    private int currentDialogIndex = 0; // Indice della finestra di dialogo attuale

    void Start()
    {
        ShowNextDialog(); // All'avvio del gioco, mostra la prima finestra di dialogo
    }

    void Update()
    {
        // Verifica se viene premuta la barra spaziale
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Controlla se la finestra di dialogo corrente è attiva e la chiude
            if (currentDialogIndex < dialogWindows.Length && dialogWindows[currentDialogIndex].activeSelf)
            {
                dialogWindows[currentDialogIndex].SetActive(false);

                // Passa alla finestra di dialogo successiva
                ShowNextDialog();
            }
        }
    }

 void ShowNextDialog()
{
    // Disattiva la finestra di dialogo corrente
    if (currentDialogIndex < dialogWindows.Length)
    {
        dialogWindows[currentDialogIndex].SetActive(false);
    }

    // Incrementa l'indice della finestra di dialogo
    currentDialogIndex++;

    // Controlla se siamo arrivati alla fine dell'array delle finestre di dialogo
    if (currentDialogIndex >= dialogWindows.Length)
    {
        // Se siamo alla fine, torniamo alla prima finestra di dialogo
        currentDialogIndex = 0;
    }

    // Mostra la finestra di dialogo corrente
    dialogWindows[currentDialogIndex].SetActive(true);
}
}

