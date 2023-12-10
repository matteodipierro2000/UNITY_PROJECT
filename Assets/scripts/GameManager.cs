using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using System.IO;

public class GameManager : MonoBehaviour
{
    public Player player;

    public TextMeshProUGUI scoreText;

    public GameObject playButton;

    public GameObject gameOver;

    public GameObject youwin;

    public GameObject button_SkyPia;

    
    private int score;
    private int key_floppy;
    public TextMesh flappy_win_text;

    private void Awake()
    {
        button_SkyPia.SetActive(false);
        string path = Application.dataPath + "/save_floppy.txt";
        if(File.Exists(path))
        {
            key_floppy=int.Parse(File.ReadAllText(path));
        }
        else
        {
            key_floppy = 0;
        }
        gameOver.SetActive(false);

        youwin.SetActive(false);

        Application.targetFrameRate = 60;

        Pause(); 
    }

    public void Play()
    {
        score = 0;

        scoreText.text = score.ToString();

        flappy_win_text.text = "";

        playButton.SetActive(false);

        gameOver.SetActive(false);

        youwin.SetActive(false);

        Time.timeScale = 1f;

        player.enabled = true;

        Asteroidi[] asteroidi = FindObjectsOfType<Asteroidi>();

        for (int i = 0; i < asteroidi.Length; i++){

            Destroy(asteroidi[i].gameObject);
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;

        player.enabled = false;

    }

    public void GameOver()

    {
        gameOver.SetActive(true);

        playButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()

    {
        score++;

        scoreText.text = score.ToString();

        if (score == 10)
        {
            key_floppy++;
            youwin.SetActive(true);
            if (key_floppy == 1)
            {
                flappy_win_text.text = "You have unlocked a memory! Let's look for it!";
            }
            //playButton.SetActive(true);
            Pause();
            string path = Application.dataPath + "/save_floppy.txt";
            File.WriteAllText(path, key_floppy.ToString());
            button_SkyPia.SetActive(true);
        }
    }
}
