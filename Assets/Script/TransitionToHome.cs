using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionToHome : MonoBehaviour
{
    void Start()
    {
        SceneManager.LoadScene(1);
    }
}
