using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

[Serializable]
public class DatabaseBehaviour : MonoBehaviour
{
    private static DatabaseBehaviour instance;
    public static int chapter;
    public static int Quizz;
    public static int score;


    public static DatabaseBehaviour Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<DatabaseBehaviour>(); // Look for existing instance in scene
                if (instance == null)
                {
                    GameObject obj = new GameObject("DatabaseBehaviour");
                    instance = obj.AddComponent<DatabaseBehaviour>(); // Create new instance if none found
                }
                DontDestroyOnLoad(instance.gameObject); // Ensure it persists across scenes
            }
            return instance;
        }
    }

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public int GetChapter()
    {
        return chapter;
    }
    public void SetChapter(int newchapter)
    {
        chapter= newchapter;
    }
    public int GetQuizz()
    {
        return Quizz;
    }
    public void SetQuizz(int newQuizzPoint)
    {
        Quizz = newQuizzPoint;
    }
    public int GetScore()
    {
        return score;
    }
    public void SetScore(int newScore)
    {
        score = newScore;
    }
}
