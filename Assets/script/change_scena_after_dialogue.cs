using UnityEngine;
using UnityEngine.SceneManagement;

public class change_scena_after_dialogue : MonoBehaviour
{
    public string sceneToLoad; // Variabile per memorizzare il nome della scena da caricare

    private void Start()
    {
        // Ottieni il componente end_dialogue dal GameObject DialogueManager
        DialogueManager dialogueManager = FindObjectOfType<DialogueManager>();

        // Aggiungi una funzione che cambierà scena in risposta all'evento di fine dialogo
        if (dialogueManager != null)
        {
            dialogueManager.GetComponent<end_dialogue>().OnDialogComplete.AddListener(ChangeScene);
        }
    }

    private void ChangeScene()
    {
        // Cambia scena una volta ricevuto l'evento di fine dialogo
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad); // Carica la scena specificata nella variabile sceneToLoad
        }
        else
        {
            Debug.LogWarning("Il nome della scena non è stato specificato.");
        }
    }
}