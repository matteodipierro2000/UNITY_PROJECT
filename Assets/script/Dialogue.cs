using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour

    {
    public GameObject[] dialogWindows; // Array contenente le finestre di dialogo
    public string sceneToLoad; // Nome della scena da caricare
    private int currentDialogIndex = 0; // Indice della finestra di dialogo attuale
    private bool isDialogueFinished = false; // Indica se il dialogo è terminato

    void Start()
    {
        currentDialogIndex = 0; // Reimposta l'indice del dialogo a zero all'avvio del gioco
        ShowNextDialog(); // Mostra la prima finestra di dialogo all'avvio
    }

    void Update()
    {
        if (!isDialogueFinished && Input.GetKeyDown(KeyCode.Space))
        {
            SkipDialog(); // Salta la finestra di dialogo corrente
        }
        else if (isDialogueFinished && Input.GetKeyDown(KeyCode.Space))
        {
            LoadNextScene(); // Cambia scena quando il dialogo è finito e premi la barra spaziatrice
        }
    }

    void SkipDialog()
    {
        if (currentDialogIndex < dialogWindows.Length && dialogWindows[currentDialogIndex].activeSelf)
        {
            dialogWindows[currentDialogIndex].SetActive(false);
            ShowNextDialog();
        }

        if (currentDialogIndex >= dialogWindows.Length)
        {
            isDialogueFinished = true;
        }
    }

    void ShowNextDialog()
    {
        if (currentDialogIndex < dialogWindows.Length)
        {
            dialogWindows[currentDialogIndex].SetActive(true);
            currentDialogIndex++;
        }
    }

    void LoadNextScene()
    {
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