using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void LoadBeginner()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void LoadIntermediate()
    {
        SceneManager.LoadSceneAsync(2);
    }
    public void LoadAdvanced()
    {
        SceneManager.LoadSceneAsync(3);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
