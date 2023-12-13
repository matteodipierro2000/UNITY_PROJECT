using UnityEngine;
using UnityEngine.Events;

public class end_dialogue : MonoBehaviour
{
    public UnityEvent OnDialogComplete; // Evento per segnalare la fine del dialogo

    // Funzione chiamata alla fine del dialogo
    public void DialogComplete()
    {
        // Emetti l'evento di fine dialogo
        if (OnDialogComplete != null)
        {
            OnDialogComplete.Invoke();
        }
    }
}
