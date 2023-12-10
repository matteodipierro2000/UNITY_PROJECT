using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class changesceneonclick_memorie : MonoBehaviour
{
    public string sceneNameToLoad0;
    public string sceneNameToLoad1; // Nome della scena da caricare, imposta questo valore nell'Inspector di Unity
    public string sceneNameToLoad2;
    public string sceneNameToLoad3;
    public string sceneNameToLoad4;
    private int chiave_memory;
    private int chiave_floppy;
    private int chiave_maze;
    private int chiave_mason;
    private void Start()
    {
        string path_memoryGame = Application.dataPath + "/save.txt";
        string path_flappy = Application.dataPath + "/save_floppy.txt";
        string path_maze = Application.dataPath + "/save_maze.txt";
        string path_mason = Application.dataPath + "/save_mason.txt";
        if (File.Exists(path_memoryGame))
        {
            chiave_memory = int.Parse(File.ReadAllText(path_memoryGame));
        }
        if (File.Exists(path_flappy))
        {
            chiave_floppy = int.Parse(File.ReadAllText(path_flappy));
        }
        if (File.Exists(path_maze))
        {
            chiave_maze = int.Parse(File.ReadAllText(path_maze));
        }
        if (File.Exists(path_mason))
        {
            chiave_mason = int.Parse(File.ReadAllText(path_mason));
        }
        if (!File.Exists(path_memoryGame))
        {
            chiave_memory = 0;
        }
        if (!File.Exists(path_flappy))
        {
            chiave_floppy = 0;
        }
        if (!File.Exists(path_maze))
        {
            chiave_maze = 0;
        }
        if (!File.Exists(path_mason))
        {
            chiave_mason = 0;
        }
        Button button = GetComponent<Button>(); // Ottieni il componente Button associato al GameObject
        if (button != null)
        {
            button.onClick.AddListener(LoadScene); // Aggiungi un listener al click del bottone che carica la scena
        }
    }

    private void LoadScene()
    {
        if (chiave_memory >=1 && chiave_mason==0 && chiave_maze==0 && chiave_floppy==0)
        {
            SceneManager.LoadScene(sceneNameToLoad1); // Carica la scena con il nome specificato
        }
        if (chiave_memory >= 1 && chiave_mason >= 1 && chiave_maze == 0 && chiave_floppy == 0)
        {
            SceneManager.LoadScene(sceneNameToLoad2); // Carica la scena con il nome specificato
        }
        if (chiave_memory >= 1 && chiave_mason >= 1 && chiave_maze >= 1 && chiave_floppy == 0)
        {
            SceneManager.LoadScene(sceneNameToLoad3); // Carica la scena con il nome specificato
        }
        if (chiave_memory >= 1 && chiave_mason >= 1 && chiave_maze >= 1 && chiave_floppy >=1)
        {
            SceneManager.LoadScene(sceneNameToLoad4); // Carica la scena con il nome specificato
        }
        if (chiave_memory == 0 && chiave_mason >= 1)
        {
            SceneManager.LoadScene(sceneNameToLoad0); // Carica la scena con il nome specificato
        }
        if (chiave_memory == 0 && chiave_mason ==0 && chiave_maze>=1)
        {
            SceneManager.LoadScene(sceneNameToLoad0); // Carica la scena con il nome specificato
        }
        if (chiave_memory == 0 && chiave_mason == 0 && chiave_maze==0 && chiave_floppy>=1)
        {
            SceneManager.LoadScene(sceneNameToLoad0); // Carica la scena con il nome specificato
        }
        if ( chiave_mason == 0 && chiave_maze >=1)
        {
            SceneManager.LoadScene(sceneNameToLoad1); // Carica la scena con il nome specificato
        }
        if (chiave_mason == 0 && chiave_maze ==0 && chiave_floppy>=1)
        {
            SceneManager.LoadScene(sceneNameToLoad1); // Carica la scena con il nome specificato
        }
        if ( chiave_maze == 0 && chiave_floppy >= 1)
        {
            SceneManager.LoadScene(sceneNameToLoad2); // Carica la scena con il nome specificato
        }
    }
}