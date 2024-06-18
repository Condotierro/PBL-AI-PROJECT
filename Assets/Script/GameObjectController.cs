using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameObjectController : MonoBehaviour
{
    public Button nextButton;

    public GameObject[] chapterGameObjects; 

    private int currentChapter = 0;
    private int totalChapters;

    void Start()
    {
        if(DatabaseBehaviour.Instance.GetChapter() != null)
        {
            currentChapter = DatabaseBehaviour.Instance.GetChapter();
        }else
        {
            currentChapter = 0;
        }
        totalChapters = chapterGameObjects.Length;

        nextButton.onClick.AddListener(NextChapter);

        StartChapter(currentChapter);
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
            DatabaseBehaviour.Instance.SetChapter(DatabaseBehaviour.Instance.GetChapter()+1);
            if(currentChapter == 23)
            {
                SceneManager.LoadSceneAsync(5);
            }
            else
            {
                ChangeChapter(currentChapter);
            }
            Debug.Log("Next Chapter: " + currentChapter);
        }
        else
        {
            Debug.Log("No more chapters.");
        }
    }

}
