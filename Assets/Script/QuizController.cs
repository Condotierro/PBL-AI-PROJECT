using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuizController : MonoBehaviour
{
    public Toggle[] toggles;

    private bool[] correctAnswers = { true, false, true, true }; // put answer here

    public Button submitButton;

    private void Start()
    {
        submitButton.onClick.AddListener(CheckAnswers);
    }
    public void CheckAnswers()
    {
        int score = 0;

        for (int i = 0; i < toggles.Length; i++)
        {
            if (toggles[i].isOn == correctAnswers[i])
            {
                score++;
            }
        }

        Debug.Log("Score: " + score + "/" + correctAnswers.Length);
    }
}
