using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
using System;

public class LLMClient : MonoBehaviour
{
    private const string apiUrl = "http://localhost:1234/v1";

    [Serializable]
    public class LLMResponse
    {
        public string text;
    }

    public void SendMessageToLLM(string userMessage, Action<string> callback)
    {
        StartCoroutine(SendPostRequest(userMessage, callback));
    }

    private IEnumerator SendPostRequest(string userMessage, Action<string> callback)
    {
        var requestData = new
        {
            prompt = userMessage,
            max_tokens = 150
        };
        string json = JsonUtility.ToJson(requestData);

        using (UnityWebRequest request = UnityWebRequest.PostWwwForm(apiUrl, json))
        {
            request.SetRequestHeader("Content-Type", "application/json");

            byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
            request.uploadHandler = new UploadHandlerRaw(bodyRaw);
            request.downloadHandler = new DownloadHandlerBuffer();

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError(request.error);
                callback("Error: " + request.error);
            }
            else
            {
                var response = JsonUtility.FromJson<LLMResponse>(request.downloadHandler.text);
                callback(response.text);
            }
        }
    }
}
