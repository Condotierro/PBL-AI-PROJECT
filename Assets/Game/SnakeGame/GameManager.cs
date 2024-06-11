using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Text scoreText;
    private int score = 0;
    public GameObject dataPrefab;
    public Transform[] spawnPoints;

    private AudioSource audioSource;
    public AudioClip collectSound;
    public AudioClip depositSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
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

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
