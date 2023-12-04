using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    public string sceneNameToLoad; // Nome della scena da caricare, imposta questo valore nell'Inspector di Unity

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // Cambia "Player" con il tag del GameObject che attiva il cambio scena
        {
            SceneManager.LoadScene(sceneNameToLoad); // Carica la scena con il nome specificato
        }
    }
}
