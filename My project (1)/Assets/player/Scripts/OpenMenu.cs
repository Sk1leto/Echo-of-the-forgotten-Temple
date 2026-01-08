using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class OpenMenu : MonoBehaviour
{
    // Start is called before the first frame update
   public GameObject menu;

   public bool PauseGame;
   
    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Resume();
                
            
            }
            else
            {
                Pause();
            }
            
            
        }
    }

    public void Resume()
    {
        menu.SetActive(false);
        Time.timeScale = 1;
        PauseGame = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Pause()
    {Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        menu.SetActive(true);
        Time.timeScale = 0;
        PauseGame = true;
    }

    public void goToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
        
    }

    public void Continue()
    {
        SceneManager.LoadScene(3);
    }

    public void goToSecondScene()
    {
        SceneManager.LoadScene(2);
    }
}
