using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class QuizManagerAdv : MonoBehaviour
{
    public List<QuestionsAdv> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GOPanel;
    public GameObject PuzzlePieces;
    public GameObject Puzzlelayout;
    public GameObject Lockcanvas;

    public GameObject completepuzbut;
    public GameObject bmm;

    public Text QuestionTxt;
    public Text ScoreTxt;

    public AudioClip winaudio;
    public AudioClip loseaudio;

    int totalQuestion = 0;
    public int scorecount;
    public int result;

    private void Start()
    {
        totalQuestion = QnA.Count;
        GOPanel.SetActive(false);
        generateQuestion();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    public void CompletePuzzle()
    {
        Quizpanel.SetActive(false);
        GOPanel.SetActive(false);
        Lockcanvas.SetActive(false);
        Puzzlelayout.SetActive(true);
        PuzzlePieces.SetActive(true);
        bmm.SetActive(true);

    }

    void GameOver()
    {
        Quizpanel.SetActive(false);
        GOPanel.SetActive(true);
        ScoreTxt.text = "Score : " + scorecount + "/" + totalQuestion;
        result = (scorecount * 100) / totalQuestion;
        if (result >= 50)
        {
            completepuzbut.SetActive(true);
            AudioSource.PlayClipAtPoint(winaudio, transform.position);
        }
        else
        {
            completepuzbut.SetActive(false);
            AudioSource.PlayClipAtPoint(loseaudio, transform.position);
        }
    }

    public void wrong()
    {
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void correct()
    {
        scorecount += 1;
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerAdv>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<Text>().text = QnA[currentQuestion].Answers[i];

            if (QnA[currentQuestion].CorrectAns == i + 1)
            {
                options[i].GetComponent<AnswerAdv>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (QnA.Count > 0)
        {
            for (int i = QnA.Count - 1; i >= 0; i--)
            {
                //currentQuestion = Random.Range(0, QnA.Count);
                currentQuestion = i;
                QuestionTxt.text = QnA[currentQuestion].Question;
                SetAnswers();
            }

        }
        else
        {
            //Debug.Log("Out of Questions");
            GameOver();
        }

    }

}
