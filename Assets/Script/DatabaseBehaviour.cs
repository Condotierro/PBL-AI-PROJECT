using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DatabaseBehaviour : MonoBehaviour
{
    private static DatabaseBehaviour instance;
    public static int chapter;

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
}
