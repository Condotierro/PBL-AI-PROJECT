using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using MiniJSON;

public class ChatManager : MonoBehaviour
{
    public GameObject chatPanel;
    public Button openChatButton;
    public TMP_InputField userInputField;
    public TextMeshProUGUI chatHistoryText;
    public Button sendButton;
    public Scrollbar scrollbar;

    private string baseUrl = "http://localhost:1234/v1";
    private string model = "lmstudio-community/Meta-Llama-3-8B-Instruct-GGUF";
    private List<Dictionary<string, string>> history = new List<Dictionary<string, string>>();

    void Start()
    {
        openChatButton.onClick.AddListener(OpenChat);
        sendButton.onClick.AddListener(OnSendButtonClicked);
        chatPanel.SetActive(false);
    }

    void OpenChat()
    {
        chatPanel.SetActive(true);
        if (scrollbar != null)
        {
            scrollbar.gameObject.SetActive(true);
        }
        InitializeChat();
    }


    void InitializeChat()
    {
        // Initialize chat history with system and user messages
        history.Add(new Dictionary<string, string> { { "role", "system" }, { "content", "Hello, i'm a AI to help you with your lesson, if you have a question ask me." } });
        DisplayChatHistory();
    }

    void OnSendButtonClicked()
    {
        string userInput = userInputField.text;
        userInputField.text = "";

        // Add user message to chat history
        history.Add(new Dictionary<string, string> { { "role", "user" }, { "content", "You : " + userInput } });
        DisplayChatHistory();
        ScrollToBottom();

        // Send user message to LLM and get response
        StartCoroutine(SendMessageToLLM(userInput));
    }

    IEnumerator SendMessageToLLM(string userMessage)
    {
        // Convert history to JSON string
        string messagesJson = Json.Serialize(history);

        // Create form for POST request
        WWWForm form = new WWWForm();
        form.AddField("model", model);
        form.AddField("messages", messagesJson);
        form.AddField("temperature", "0.7");
        form.AddField("stream", "true");

        // Send POST request to LLM
        using (WWW www = new WWW(baseUrl + "/chat/completions", form))
        {
            yield return www;

            if (!string.IsNullOrEmpty(www.error))
            {
                Debug.LogError("Error sending message to LLM: " + www.error);
                yield break;
            }

            // Handle LLM response
            StartCoroutine(ProcessLLMResponse(www.text));
        }
    }

    IEnumerator ProcessLLMResponse(string responseJson)
    {
        // Parse LLM response JSON
        var response = Json.Deserialize(responseJson) as Dictionary<string, object>;
        var choices = response["choices"] as List<object>;

        // Process choices and update chat history
        foreach (var choice in choices)
        {
            var choiceDict = choice as Dictionary<string, object>;
            var message = choiceDict["message"] as Dictionary<string, object>;
            var role = message["role"] as string;
            var content = message["content"] as string;

            // Add assistant message to chat history
            history.Add(new Dictionary<string, string> { { "role", role }, { "content", content } });

            // Display the newly received token
            DisplayChatHistory();

            // Wait for a short time to simulate token-by-token update
            yield return new WaitForSeconds(0.5f); // Adjust this delay as needed
        }

        // Scroll to the bottom of the chat panel
        ScrollToBottom();
    }

    void DisplayChatHistory()
    {
        chatHistoryText.text = "";
        foreach (var message in history)
        {
            string role = message["role"];
            string content = message["content"];
            string displayMessage = $"<color={(role == "user" ? "white" : (role == "assistant" ? "green" : "green"))}>{content}</color>";
            chatHistoryText.text += displayMessage + "\n";
        }
    }

    void ScrollToBottom()
    {
        scrollbar.value = 0;
    }
}
