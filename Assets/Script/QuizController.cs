using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro; // Import TextMeshPro namespace

public class QuizController : MonoBehaviour
{
    public Toggle[] toggles; // Array of toggle buttons
    public Button submitButton; // Submit button
    public TextMeshProUGUI questionText; // TextMesh Pro field to display the question
    public TextMeshProUGUI scoreText; // TextMesh Pro field to display the score

    private int currentQuestionIndex = 0;
    private int score = 0;

    // List of questions and their correct answers
    private List<Question> questions = new List<Question>()
    {
        new Question("Which of the following best describes a key characteristic of Machine Learning (ML)? ", new bool[] { true, false, true, true }, new string[] { "The ability of machines to operate independently without pre-defined rules ", "The process by which machines improve their performance on tasks by learning from data", "The simulation of human conversation through predefined responses ", "The construction of physical models to predict future trends " }),
        new Question("What is the primary objective of Natural Language Processing (NLP) within AI? ", new bool[] { false, false, true, false }, new string[] { "To develop algorithms for high-speed computations", "To enable machines to interpret and respond to human language in a meaningful way", "To control autonomous robotic systems ", "To analyse and visualize large data sets" }),
        new Question("In the context of AI, what is Supervised Learning? ", new bool[] { true, true, true, true }, new string[] { "A technique where the model discovers hidden patterns in unlabeled data ", "A method where the model learns from labeled training data to make predictions or decisions", "An approach where the model receives continuous feedback through rewards or penalties", "A process of training models using reinforcement signals from their own actions" }),
        new Question("What is a significant ethical concern related to the deployment of AI systems? ", new bool[] { true, true, true, true }, new string[] { "The increased computational power required by AI systems", "The potential for AI systems to perpetuate or amplify biases present in the training data", "The development of faster algorithms for data processing", "The reliance on cloud-based storage solutions " }),
        new Question("Which type of learning in AI involves an agent learning to make decisions by receiving rewards or penalties? ", new bool[] { true, true, true, true }, new string[] { "Supervised Learning", "Unsupervised Learning", "Reinforcement Learning", "Transfer Learning" }),
    };

    private void Start()
    {
        submitButton.onClick.AddListener(CheckAnswers);
        LoadQuestion();
    }

    private void LoadQuestion()
    {
        if (currentQuestionIndex < questions.Count)
        {
            questionText.text = questions[currentQuestionIndex].Text;

            // Set toggles for the new question
            for (int i = 0; i < toggles.Length; i++)
            {
                toggles[i].isOn = false; // Reset toggle state
                Text toggleLabel = toggles[i].GetComponentInChildren<Text>();
                toggleLabel.text = questions[currentQuestionIndex].ToggleTexts[i];
            }
        }
        else
        {
            // End of quiz
            questionText.text = "Quiz Completed!";
            submitButton.interactable = false; // Disable submit button
        }
    }

    public void CheckAnswers()
    {
        if (currentQuestionIndex < questions.Count)
        {
            bool[] correctAnswers = questions[currentQuestionIndex].CorrectAnswers;

            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i].isOn == correctAnswers[i])
                {
                    score++;
                }
            }

            scoreText.text = "Score: " + score + "/" + (currentQuestionIndex + 1) * toggles.Length;
            currentQuestionIndex++;
            LoadQuestion();
        }
    }
}

[System.Serializable]
public class Question
{
    public string Text;
    public bool[] CorrectAnswers;
    public string[] ToggleTexts; // Array of texts for the toggles

    public Question(string text, bool[] correctAnswers, string[] toggleTexts)
    {
        Text = text;
        CorrectAnswers = correctAnswers;
        ToggleTexts = toggleTexts;
    }
}
