using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;

    public float durata = 0.5f;

    public Quizmanager quizmanager;

    public Color StartColor;

    private void Start()
    {
        StartColor = GetComponent<Image>().color;
    }

    public void Answer()
    {
        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;

            Invoke("Nascondi_Colore", durata);

            Debug.Log("CorrectAnswer");

            quizmanager.correct();
        }

        else
        {
            GetComponent<Image>().color = Color.red;

            Invoke("Nascondi_Colore", durata);

            Debug.Log("WrongAnswer");

            quizmanager.wrong();

        }
    }

    public void Nascondi_Colore()
    {
        GetComponent<Image>().color = Color.white;
    }

}
