using UnityEngine;
using UnityEngine.UI;

public class GameObjectController : MonoBehaviour
{
    public Button nextButton;

    public GameObject[] chapterGameObjects; 

    private int currentChapter = 0;
    private int totalChapters;

    void Start()
    {
        currentChapter = 0;
        totalChapters = chapterGameObjects.Length;

        nextButton.onClick.AddListener(NextChapter);

        StartChapter(0);
    }

    void StartChapter(int chapter)
    {
        for (int i = 0; i < chapterGameObjects.Length; i++)
        {
            chapterGameObjects[i].SetActive(false);
        }
        chapterGameObjects[chapter].SetActive(true);
    }

    void ChangeChapter(int chapter)
    {
        chapterGameObjects[currentChapter-1].SetActive(false);
        chapterGameObjects[currentChapter].SetActive(true);
    }

    void NextChapter()
    {
        if (currentChapter < totalChapters-1)
        {
            currentChapter++;
            ChangeChapter(currentChapter);
            Debug.Log("Next Chapter: " + currentChapter);
        }
        else
        {
            Debug.Log("No more chapters.");
        }
    }


}
