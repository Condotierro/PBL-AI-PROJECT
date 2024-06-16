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
    }


}
