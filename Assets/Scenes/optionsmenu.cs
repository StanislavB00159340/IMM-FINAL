using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{
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
