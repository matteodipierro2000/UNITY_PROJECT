using UnityEngine;

public class Visualizzazionecanvas : MonoBehaviour
{
    public Canvas Canvas;

    private void Start()
    {
        if (Canvas != null)
        {
            Canvas.enabled = true;
        }

        else
        {
            Debug.LogError("Canvas non assegnato al componente Visualizzazionecanvas");
        }
    }
}
