using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource hoversound;
    public AudioSource clicksound;

    public void hoverSound()
    {
        hoversound.Play();
    }

    public void clickSound()
    {
        clicksound.Play();
    }

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
        SceneManager.LoadScene(2);
    }

    public void Medium()
    {
        SceneManager.LoadScene(3);
    }

    public void Hard()
    {
        SceneManager.LoadScene(4);
    }

    public void OpenGitHub()
    {
        Application.OpenURL("https://github.com/StanislavB00159340/IMM-FINAL"); 
    }
}
