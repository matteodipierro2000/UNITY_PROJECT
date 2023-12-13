using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class Attrezzo_C : MonoBehaviour
{
    public float minY = -5.5f;

    public float maxVelocity = 10f;

    Rigidbody2D rb;

    int score = 0;

    int lives = 24;

    public TextMeshProUGUI scoreTxt;

    public TextMeshProUGUI livesTxt;

    public GameObject GameOverPanel;

    public GameObject youWinPanel;

    public GameObject MainSceneButton;

    [SerializeField] private TextMesh Unlock_memory;

    public Attrezzo_C attrezzo;

    public player_movement_C muratore;

    int brickCount;

    int keys_mason;

    void Start()
    {
        string path = Application.dataPath + "/save_mason.txt";
        if (File.Exists(path))
        {
            keys_mason = int.Parse(File.ReadAllText(path));
        }
        else
        {
            keys_mason = 0;
        }
        rb = GetComponent<Rigidbody2D>();

        brickCount = FindObjectOfType<LevelGenerator_C>().transform.childCount;

        rb.velocity = Vector2.down * 10f;

        MainSceneButton.SetActive(false);



    }


    void Update()
    {
        if (transform.position.y < minY)
        {
            if (lives <= 0)
            {
                GameOver();
            }

            else
            {
                transform.position = Vector3.zero;

                rb.velocity = Vector2.down * 10f;

                lives--;

                livesTxt.text = lives.ToString("00");
            }


        }

        if (rb.velocity.magnitude > maxVelocity)
        {
            rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxVelocity);
        }
    }

    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("brick"))
        {
            Destroy(collision.gameObject);

            score += 1;

            scoreTxt.text = score.ToString("00");

            brickCount--;

            if (brickCount <= 0)
            {
                youWinPanel.SetActive(true);

                MainSceneButton.SetActive(true);

                muratore.enabled = false;

                attrezzo.enabled = false;

                Time.timeScale = 0f;
                keys_mason++;
                string path = Application.dataPath + "/save_mason.txt";
                File.WriteAllText(path, keys_mason.ToString());
                if (keys_mason == 1)
                {
                    Unlock_memory.text = "You have unlocked a memory! Let's look for it!";
                    yield return new WaitForSeconds(5f);
                    Unlock_memory.text = "";
                }
            }
        }
    }

    void GameOver()
    {
        GameOverPanel.SetActive(true);

        Time.timeScale = 0;

        Destroy(gameObject);
    }
}

