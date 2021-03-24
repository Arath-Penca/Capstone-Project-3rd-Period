using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    bool isJumping = false;
   public void PlayGame()
    {
       
    }

    public void QuitGame()
    {
        Application.Quit();
        if (Input.GetKey(KeyCode.G))
        {
            Application.Quit();
        }
        Debug.Log("working");
    }



}
