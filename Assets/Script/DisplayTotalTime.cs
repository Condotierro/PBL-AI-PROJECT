using UnityEngine;
using TMPro;

public class DisplayTotalTime : MonoBehaviour
{
    public TextMeshProUGUI timeText; // Reference to your TextMeshProUGUI element

    void Start()
    {
        // Ensure we have a reference to the TextMeshProUGUI component
        if (timeText == null)
        {
            Debug.LogError("TextMeshProUGUI reference not set in DisplayTotalTime script.");
            return;
        }
    }

    void Update()
    {
        // Update the displayed time every frame
        UpdateTimeDisplay();
    }

    void UpdateTimeDisplay()
    {
        // Access the TimeManager singleton instance and get the formatted total time
        string formattedTime = TimeManager.Instance.GetFormattedTotalTime();

        // Update the TextMeshProUGUI element
        timeText.text = formattedTime;
    }
}
