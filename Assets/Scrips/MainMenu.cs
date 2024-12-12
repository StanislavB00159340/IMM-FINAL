using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        SceneManager.LoadScene(1);
    }

    public void quitGame()
    {
        Application.Quit();
    }
    
    

    public void Easy()
    {
        SceneManager.LoadScene(3);
    }
    public void Medium()
    {
        SceneManager.LoadScene(4);
    }
     public void Hard()
    {
        SceneManager.LoadScene(5);
    }

  

    
}
