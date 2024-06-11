using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    private int score = 0;
    public GameObject dataPrefab;
    public Transform[] spawnPoints;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CollectData()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void SpawnNewData()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(dataPrefab, spawnPoints[spawnIndex].position, Quaternion.identity);
    }
}
