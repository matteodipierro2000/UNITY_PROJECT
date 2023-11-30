using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changesceneonclick : MonoBehaviour
{
    public string sceneNameToLoad; // Nome della scena da caricare, imposta questo valore nell'Inspector di Unity

    private void Start()
    {
        Button button = GetComponent<Button>(); // Ottieni il componente Button associato al GameObject
        if (button != null)
        {
            button.onClick.AddListener(LoadScene); // Aggiungi un listener al click del bottone che carica la scena
        }
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneNameToLoad); // Carica la scena con il nome specificato
    }
}