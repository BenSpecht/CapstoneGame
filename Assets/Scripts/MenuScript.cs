using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{


    public void ButtonPlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

    public void Credit()
    {
        
        
        
    }

    public void ButtonQuit()
    {
        Debug.Log("LET ME OUT");
        Application.Quit();
        
    }
}
