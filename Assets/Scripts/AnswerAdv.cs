using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerAdv : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManagerAdv quizManager;

    public void Answers()
    {
        if (isCorrect)
        {
            //Debug.Log("Correct Answer");
            quizManager.correct();
        }

        else
        {
            //Debug.Log("Wrong Answer");
            quizManager.wrong();
        }
    }
}
