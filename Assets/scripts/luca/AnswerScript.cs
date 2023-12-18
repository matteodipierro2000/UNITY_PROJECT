using System.Collections;
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
        // Memorizza l'indice della risposta corretta
        int correctAnswerIndex = quizmanager.QnA[quizmanager.CurrentQuestion].CorrectAnswer - 1;

        // Itera su tutte le opzioni
        for (int i = 0; i < quizmanager.options.Length; i++)
        {
            // Imposta il colore della risposta corretta in verde
            if (i == correctAnswerIndex)
            {
                quizmanager.options[i].GetComponent<Image>().color = Color.green;
            }
        }

        if (isCorrect)
        {
            GetComponent<Image>().color = Color.green;

            // Utilizza una coroutine per attendere il periodo specificato prima di nascondere il colore
            StartCoroutine(NascondiColoreDopoDelay(correctAnswerIndex));

            Debug.Log("CorrectAnswer");

            quizmanager.correct();
        }
        else
        {
            GetComponent<Image>().color = Color.red;

            // Utilizza una coroutine per attendere il periodo specificato prima di nascondere il colore
            StartCoroutine(NascondiColoreDopoDelay(correctAnswerIndex));

            Debug.Log("WrongAnswer");

            quizmanager.wrong();
        }
    }

    // Coroutine per attendere il periodo specificato prima di nascondere il colore
    IEnumerator NascondiColoreDopoDelay(int correctAnswerIndex)
    {
        yield return new WaitForSeconds(durata);

        // Riporta il colore della risposta corretta a bianco
        quizmanager.options[correctAnswerIndex].GetComponent<Image>().color = Color.white;

        // Riporta il colore della risposta selezionata a bianco
        GetComponent<Image>().color = Color.white;
    }
}