using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PauseMenu : MonoBehaviour
{
    private bool isPaused = false;
    [SerializeField] GameObject exitButton;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        Pause();
    }
    public void Pause()
    {
        isPaused = !isPaused;
        if(isPaused)
        {
            
            exitButton.SetActive(true);
        }
        else if(!isPaused)
        {
            
            exitButton.SetActive(false);
        }

    }
    public void CloseGame()
    {
        Application.Quit();
    }
    
}
