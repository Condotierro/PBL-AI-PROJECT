using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
        new Question("Which of the following best describes a key characteristic of Machine Learning (ML)? ", new bool[] { false, true, false, false }, new string[] { "The ability of machines to operate independently without pre-defined rules ", "The process by which machines improve their performance on tasks by learning from data", "The simulation of human conversation through predefined responses ", "The construction of physical models to predict future trends " }),
        new Question("What is the primary objective of Natural Language Processing (NLP) within AI? ", new bool[] { false, true, false, false }, new string[] { "To develop algorithms for high-speed computations", "To enable machines to interpret and respond to human language in a meaningful way", "To control autonomous robotic systems ", "To analyse and visualize large data sets" }),
        new Question("In the context of AI, what is Supervised Learning? ", new bool[] { false, true, false, false }, new string[] { "A technique where the model discovers hidden patterns in unlabeled data ", "A method where the model learns from labeled training data to make predictions or decisions", "An approach where the model receives continuous feedback through rewards or penalties", "A process of training models using reinforcement signals from their own actions" }),
        new Question("What is a significant ethical concern related to the deployment of AI systems? ", new bool[] { false, true, false, false }, new string[] { "The increased computational power required by AI systems", "The potential for AI systems to perpetuate or amplify biases present in the training data", "The development of faster algorithms for data processing", "The reliance on cloud-based storage solutions " }),
        new Question("Which type of learning in AI involves an agent learning to make decisions by receiving rewards or penalties? ", new bool[] { false, false, true, false }, new string[] { "Supervised Learning", "Unsupervised Learning", "Reinforcement Learning", "Transfer Learning" }),
        new Question("What is a significant challenge associated with Large Language Models (LLMs)?  ", new bool[] { false, false, true, false }, new string[] { "They are limited to only a few specific language tasks.", "They do not require significant computational resources ", "They can inherit biases present in their training data.", "They are incapable of maintaining context over long passages of text." }),
        new Question("In what way are Large Language Models (LLMs) often used in the education sector? ", new bool[] { false, true, false, false }, new string[] { "To automate financial transactions", "To generate study materials and provide tutoring support", "To control autonomous vehicles", "To diagnose medical conditions based on images" }),
        new Question("How do LLMs improve customer support? ", new bool[] { false, true, false, false }, new string[] { "By automating financial transactions", "By enhancing chatbots and virtual assistants", "By diagnosing medical conditions", "By controlling autonomous vehicles" }),
        new Question("What is an example of an ethical concern related to LLMs? ", new bool[] { false, false, true, false }, new string[] { "Reduced computational power", "Increased accuracy in data processing", "Potential misuse of personal data", "Enhanced image recognition capabilities" }),
        new Question("What future direction aims to reduce the computational requirements of LLMs? ", new bool[] { false, true, false, false }, new string[] { "Enhancing fairness", "Improving efficiency", "Expanding capabilities", "Establishing ethical frameworks" }),
        new Question("What is not a significant challenge associated with Deep Learning (DL)? ", new bool[] { true, false, false, false }, new string[] { "DL models have vastly limited applications.", "DL models require large amounts of data for training.", "DL models can inherit biases from training data.", "DL models need significant computational resources." }),
        new Question("In what way are Deep Learning (DL) models often used in healthcare? ", new bool[] { false, true, false, false }, new string[] { "To automate patient billing processes.", "To diagnose diseases from medical images.", "To develop new pharmaceuticals.", "To manage patient records." }),
        new Question("How do DL models improve image and video analysis? ", new bool[] { false, false, true, false }, new string[] { "By enhancing image compression algorithms.", "By improving video streaming quality.", "By enabling tasks like image classification and object detection.", "By providing better image editing tools." }),
        new Question("What is an example of an ethical concern related to DL models? ", new bool[] { true, false, true, false }, new string[] { "Reduced transparency in decision-making processes.", "Increased accuracy in data processing.", "Potential misuse of biased data leading to unfair outcomes.", "Improved accuracy in scientific research." }),
        new Question("What future direction aims to reduce the computational requirements of DL models? ", new bool[] { false, false, false, true }, new string[] { "Improving explainability.", "Enhancing fairness.", "Establishing ethical frameworks.", "Developing efficient algorithms." }),
};

    private void Start()
    {
        Debug.Log("Start method called");
        if (submitButton != null)
        {
            submitButton.onClick.AddListener(CheckAnswers);
        }
        else
        {
            Debug.LogError("SubmitButton is not assigned in the Inspector.");
        }

        LoadQuestion();
    }

    private void LoadQuestion()
    {
        Debug.Log("LoadQuestion method called");
        if (currentQuestionIndex < questions.Count)
        {
            questionText.text = questions[currentQuestionIndex].Text;

            // Set toggles for the new question
            for (int i = 0; i < toggles.Length; i++)
            {

                toggles[i].isOn = false; // Reset toggle state

                TextMeshProUGUI toggleLabel = toggles[i].GetComponentInChildren<TextMeshProUGUI>();
                if (toggleLabel != null)
                {
                    toggleLabel.text = questions[currentQuestionIndex].ToggleTexts[i];
                }
                else
                {
                    Debug.LogError("Toggle is not assigned in the Inspector.");
                }
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
        Debug.Log("CheckAnswers method called");
        if (currentQuestionIndex < questions.Count)
        {
            bool[] correctAnswers = questions[currentQuestionIndex].CorrectAnswers;

            for (int i = 0; i < toggles.Length; i++)
            {
                if (toggles[i] != null && toggles[i].isOn == correctAnswers[i])
                {
                    score++;
                }
            }

            if (scoreText != null)
            {
                scoreText.text = "Score: " + score + "/" + ((currentQuestionIndex + 1) * toggles.Length);
            }
            else
            {
                Debug.LogError("ScoreText is not assigned in the Inspector.");
            }

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
