using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changesceneonclickGames : MonoBehaviour
{
    public string sceneNameToLoad; // Nome della scena da caricare, imposta questo valore nell'Inspector di Unity

    private void Start()
    {
        Button buttong = GetComponent<Button>(); // Ottieni il componente Button associato al GameObject
        if (buttong != null)
        {
            buttong.onClick.AddListener(LoadSceneGames); // Aggiungi un listener al click del bottone che carica la scena
        }
    }

    private void LoadSceneGames()
    {
        SceneManager.LoadScene(sceneNameToLoad); // Carica la scena con il nome specificato
    }
}