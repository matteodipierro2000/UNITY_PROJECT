using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovePlayer : MonoBehaviour
{
    private float speed = 2.5f;
    [SerializeField] private GameObject fire1;
    [SerializeField] private GameObject fire2;
    [SerializeField] private GameObject fire3;
    [SerializeField] private GameObject wwin;
    [SerializeField] private GameObject llose;
    private bool sw = false;
    private bool sw2 = false;
    private bool sw3 = false;
    private bool bl = false;
    private Vector3 startPositioN1;
    private Vector3 startPositioN2;
    private Vector3 startPositioN3;
    private Vector3 startPos;
    [SerializeField] private TextMesh timerText;
    private float startTime;
    float t;
    float minutes;
    float seconds;
    int t2 ;
    string t3;
    private int key_maze;
    [SerializeField] private TextMesh maze_win_text;
    private bool isTimerRunning=true;
    // Start is called before the first frame update
    void Start()
    {
        startPositioN1 = fire1.transform.transform.position;
        startPositioN2 = fire2.transform.transform.position;
        startPositioN3 = fire3.transform.transform.position;
        startPos = transform.position;
        startTime = Time.time;
        string path = Application.dataPath + "/save_maze.txt";
        if (File.Exists(path))
        {
            key_maze = int.Parse(File.ReadAllText(path));
        }
        else
        {
            key_maze = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (sw == true)
        {
            fire1.transform.position = fire1.transform.position + new Vector3(+1f, 0, 0) * speed * Time.deltaTime;
            if (fire1.transform.position.x >= startPositioN1.x)
            {
                sw = false;
            }
        }
        else if (sw == false)
        {
            fire1.transform.position = fire1.transform.position + new Vector3(-1f, 0, 0) * speed * Time.deltaTime;
            if (fire1.transform.position.x <= -5)
            {
                sw = true;
            }
        }
        if (sw2 == true)
        {
            fire2.transform.position = fire2.transform.position + new Vector3(+1f, 0, 0) * speed * Time.deltaTime;
            if (fire2.transform.position.x >= startPositioN2.x)
            {
                sw2 = false;
            }
        }
        else if (sw2 == false)
        {
            fire2.transform.position = fire2.transform.position + new Vector3(-1f, 0, 0) * speed * Time.deltaTime;
            if (fire2.transform.position.x <= +2.7)
            {
                sw2 = true;
            }
        }
        if (sw3 == true)
        {
            fire3.transform.position = fire3.transform.position + new Vector3(-1f, 0, 0) * speed * Time.deltaTime;
            if (fire3.transform.position.x <= startPositioN3.x)
            {
                sw3 = false;
            }
        }
        else if (sw3 == false)
        {
            fire3.transform.position = fire3.transform.position + new Vector3(+1f, 0, 0) * speed * Time.deltaTime;
            if (fire3.transform.position.x >= +5)
            {
                sw3 = true;
            }
        }
        //while (fire1.transform.position.x<-1.34)
        //{
        //fire1.transform.position = fire1.transform.position + new Vector3(+ 0.1f, 0, 0) * Time.deltaTime;
        //}

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position = transform.position + new Vector3(-1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position = transform.position + new Vector3(1, 0, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position = transform.position + new Vector3(0, 1, 0) * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position = transform.position + new Vector3(0, -1, 0) * speed * Time.deltaTime;
        }
        if (isTimerRunning)
        {
            float t = Time.time - startTime;
            //float minutes = ((int)t / 60);
            float seconds = t;
            int t2 = 60 - (int)seconds;
            string t3 = t2.ToString();
            timerText.text = "Timer: " + t3 + " sec";
            if (t2 == 0)
            {
                bl = true;
            }
            if (bl == true)
            {
                timerText.text = "Timer: 0 sec";
                StartCoroutine(losee());
            }
        }
    }
    private IEnumerator losee()
    {
        llose.transform.position = new Vector3(0, 0, -1);
        yield return new WaitForSeconds(2);
        llose.transform.position = new Vector3(0, 0, 1);
        SceneManager.LoadScene("maze");
        bl = false;
    }
    private IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "fire1")
        {
            transform.position = startPos;
        }
        if (collision.gameObject.name == "fire2")
        {
            transform.position = startPos;
        }
        if (collision.gameObject.name == "fire3")
        {
            transform.position = startPos;
        }
        if (collision.gameObject.name == "astronave_0")
        {
            isTimerRunning = false;
            key_maze++;
            if (key_maze == 1)
            {
                maze_win_text.text = "You have unlocked a memory! Let's look for it!";
            }
            string path = Application.dataPath + "/save_maze.txt";
            File.WriteAllText(path, key_maze.ToString());
            wwin.transform.position = new Vector3(0,0,-1);
            yield return new WaitForSeconds(2);
            maze_win_text.text = "";
            wwin.transform.position = new Vector3(0, 0, 1);
            SceneManager.LoadScene("takeoff");
        }
    }

}

