using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private static TimeManager instance;
    private float totalTimeInSeconds;
    private float lastSaveTime;

    // Singleton instance property
    public static TimeManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<TimeManager>(); // Look for existing instance in scene
                if (instance == null)
                {
                    GameObject obj = new GameObject("TimeManager");
                    instance = obj.AddComponent<TimeManager>(); // Create new instance if none found
                }
                DontDestroyOnLoad(instance.gameObject); // Ensure it persists across scenes
            }
            return instance;
        }
    }

    void Start()
    {
        // Load previously saved total time
        totalTimeInSeconds = PlayerPrefs.GetFloat("TotalTime", 0f);
        lastSaveTime = Time.realtimeSinceStartup;

        // Start counting time
        InvokeRepeating("UpdateTotalTime", 1f, 1f); // Update every second
    }

    void UpdateTotalTime()
    {
        float currentTime = Time.realtimeSinceStartup;
        float deltaTime = currentTime - lastSaveTime;

        totalTimeInSeconds += deltaTime;

        // Save the updated total time
        PlayerPrefs.SetFloat("TotalTime", totalTimeInSeconds);

        // Update last save time
        lastSaveTime = currentTime;
    }

    public string GetFormattedTotalTime()
    {
        int hours = Mathf.FloorToInt(totalTimeInSeconds / 3600);
        int minutes = Mathf.FloorToInt((totalTimeInSeconds % 3600) / 60);
        int seconds = Mathf.FloorToInt(totalTimeInSeconds % 60);

        return string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }
}
