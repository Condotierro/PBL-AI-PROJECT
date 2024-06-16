using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DatabaseBehaviour : MonoBehaviour
{
    
    public static int timePassed;
    public static int chapter;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        StartCoroutine(waiter());
    }

    public IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(1f);
        timePassed++;
        Debug.Log("Current time passed is " + timePassed);
        StartCoroutine(waiter());
    }
}
