                                                                                            using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    [SerializeField ] Canvas canvas; 
    private bool isOpen = false;
  
    [SerializeField]  GameObject menu;

    void Start()
    {
      
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isOpen == true)
            {
                
                CloseCanvasLetter();
                

            }

        }
    }

    public void ActivateCanvasLetter()
    {Time.timeScale = 0;
        isOpen = true;
        canvas.gameObject.SetActive(true);
        menu.SetActive(false);
        
    }

    public void CloseCanvasLetter()
    {
        Time.timeScale = 1;
        isOpen = false;
        canvas.gameObject.SetActive(false);
        menu.SetActive(true);
    }
}
