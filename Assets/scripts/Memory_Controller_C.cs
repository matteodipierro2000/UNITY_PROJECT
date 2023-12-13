using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Memory_Controller_C : MonoBehaviour
{
    private int chiave_memory;
    private int chiave_floppy;
    private int chiave_maze;
    private int chiave_mason;
    [SerializeField] private GameObject memoria1;
    [SerializeField] private GameObject memoria2;
    [SerializeField] private GameObject memoria3;
    [SerializeField] private GameObject memoria4;
    [SerializeField] private GameObject lucchetto1;
    [SerializeField] private GameObject lucchetto2;
    [SerializeField] private GameObject lucchetto3;
    [SerializeField] private GameObject lucchetto4;
    [SerializeField] private GameObject blocco1;
    [SerializeField] private GameObject blocco2;
    [SerializeField] private GameObject blocco3;
    [SerializeField] private GameObject blocco4;
    [SerializeField] private GameObject lucchetto_piccolo1;
    [SerializeField] private GameObject lucchetto_piccolo2;
    [SerializeField] private GameObject lucchetto_piccolo3;
    [SerializeField] private GameObject lucchetto_piccolo4;
    [SerializeField] private TextMesh testo1;
    [SerializeField] private TextMesh testo2;
    [SerializeField] private TextMesh testo3;
    [SerializeField] private TextMesh testo4;
    // Start is called before the first frame update
    void Start()
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
        if (chiave_memory == 0)
        {
            memoria1.SetActive(false);
            testo1.text = "";
        }
        if (chiave_floppy == 0)
        {
            memoria4.SetActive(false);
            testo4.text = "";
        }
        if (chiave_maze == 0)
        {
            memoria3.SetActive(false);
            testo3.text = "";
        }
        if (chiave_mason == 0)
        {
            memoria2.SetActive(false);
            testo2.text = "";
        }
        if (chiave_memory >= 1)
        {
            lucchetto1.SetActive(false);
            lucchetto_piccolo1.SetActive(false);
        }
        if (chiave_floppy >= 1)
        {
            lucchetto4.SetActive(false);
            lucchetto_piccolo4.SetActive(false);
        }
        if (chiave_maze >= 1)
        {
            lucchetto3.SetActive(false);
            lucchetto_piccolo3.SetActive(false);
        }
        if (chiave_mason >= 1)
        {
            lucchetto2.SetActive(false);
            lucchetto_piccolo2.SetActive(false);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
