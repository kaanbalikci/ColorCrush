using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
   
    public void StartScene()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitApp()
    {
        Application.Quit();
    }

}
