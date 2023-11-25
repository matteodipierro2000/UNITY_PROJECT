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
        // Controlla se c'è un'altra finestra di dialogo successiva nell'array
        if (currentDialogIndex < dialogWindows.Length - 1)
        {
            currentDialogIndex++;
            dialogWindows[currentDialogIndex].SetActive(true);
        }
        else
        {
            // Se non ci sono altre finestre di dialogo nell'array, reimposta l'indice
            currentDialogIndex = 0;
        }
    }
}

