using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void LoadHome()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadCourse()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void LoadQuiz()
    {
        SceneManager.LoadSceneAsync(3);
    }
}
