
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Quizmanager : MonoBehaviour
{
    public List<QuestionAndAnswer> QnA;

    public GameObject[] options;

    public int CurrentQuestion;

    public GameObject QuizPanel;

    public GameObject GoPanel;

    //public GameObject Wrong_Panel;

    //public GameObject Right_Panel;

    public float durata = 0.5f;

    public TextMeshProUGUI QuestionTxt;

    public TextMeshProUGUI ScoreTxt;

    int totalquestions = 0;

    public int score;

    private void Start()
    {
        totalquestions = QnA.Count;

        //Wrong_Panel.SetActive(false);

        //Right_Panel.SetActive(false);

        GoPanel.SetActive(false);

        GenerateQuestions();
    }

    //public void Retry()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}

    public void GameOver()
    {
        QuizPanel.SetActive(false);

        //Wrong_Panel.SetActive(false);

        //Right_Panel.SetActive(false);

        GoPanel.SetActive(true);

        ScoreTxt.text = score + "/" + totalquestions;
    }

    public void correct()
    {
        score += 1;

        QnA.RemoveAt(CurrentQuestion);

        //Right_Panel.SetActive(true);

        //Invoke("Nascondi_Right_Panel", durata);

        //Wrong_Panel.SetActive(false);

        GenerateQuestions();
    }

    public void wrong()
    {
        QnA.RemoveAt(CurrentQuestion);

        //Wrong_Panel.SetActive(true);

        //Invoke("Nascondi_Wrong_Panel", durata);

        //Right_Panel.SetActive(false);

        GenerateQuestions();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            //options[i].GetComponent<Image>().color = options[i].GetComponent<AnswerScript>().StartColor;

            options[i].GetComponent<AnswerScript>().isCorrect = false;

            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[CurrentQuestion].Answers[i];

            if (QnA[CurrentQuestion].CorrectAnswer == i + 1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void GenerateQuestions()
    {
        if (QnA.Count > 0)
        {
            CurrentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[CurrentQuestion].Question;

            SetAnswers();
        }

        else
        {
            Debug.Log("OutOfQuestions");

            GameOver();
        }

    }

    //public void Nascondi_Right_Panel()
    //{
    //Right_Panel.SetActive(false);
    //}

    //public void Nascondi_Wrong_Panel()
    //{
    //Wrong_Panel.SetActive(false);
    //}
}