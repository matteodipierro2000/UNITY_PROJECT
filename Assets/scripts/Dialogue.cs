using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    public GameObject[] dialogWindows;
    public string sceneToLoad;
    private int currentDialogIndex = 0;
    private bool isDialogueFinished = false;
    private bool dialogueInputEnabled = true; // Variabile per abilitare/disabilitare l'input per il dialogo

    void Start()
    {
        ResetDialogue();
    }

    void Update()
    {
        if (dialogueInputEnabled && Input.GetKeyDown(KeyCode.Space))
        {
            AdvanceDialog();
        }
        else if (isDialogueFinished && Input.GetKeyDown(KeyCode.S))
        {
            LoadNextScene();
        }
    }

    void AdvanceDialog()
    {
        if (currentDialogIndex < dialogWindows.Length && dialogWindows[currentDialogIndex].activeSelf)
        {
            dialogWindows[currentDialogIndex].SetActive(false);
            currentDialogIndex++;

            if (currentDialogIndex < dialogWindows.Length)
            {
                dialogWindows[currentDialogIndex].SetActive(true);
            }
            else
            {
                isDialogueFinished = true;
                dialogueInputEnabled = false; // Disabilita l'input per il dialogo quando finisce
            }
        }
    }

    void LoadNextScene()
    {
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("Il nome della scena non è stato specificato.");
        }
    }

    public void ResetDialogue()
    {
        currentDialogIndex = 0;
        isDialogueFinished = false;
        dialogueInputEnabled = true; // Assicura che l'input per il dialogo sia abilitato quando viene resettato
        foreach (GameObject window in dialogWindows)
        {
            window.SetActive(false);
        }
        if (dialogWindows.Length > 0)
        {
            dialogWindows[0].SetActive(true);
        }
    }
}