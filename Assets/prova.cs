using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prova : MonoBehaviour
{
    // Assicurati di collegare il GameObject della finestra di dialogo a questo script nell'Editor di Unity
    public GameObject dialogWindow;

    void Update()
    {
        // Verifica se viene premuta la barra spaziatrice
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Controlla se la finestra di dialogo è attiva prima di nasconderla
            if (dialogWindow.activeSelf)
            {
                // Nascondi la finestra di dialogo
                dialogWindow.SetActive(false);
            }
        }
    }
}
    
