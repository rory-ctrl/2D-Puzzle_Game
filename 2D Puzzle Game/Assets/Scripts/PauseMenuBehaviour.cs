using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuBehaviour : MainMenuBehaviour
{
    public static bool isPaused;
    public GameObject pauseMenu;

    private void Start()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
    }

    public void Update()
    {
        if(Input.GetKeyUp("escape"))
        {
            isPaused = true;
            Time.timeScale = (isPaused) ? 0 : 1;
            pauseMenu.SetActive(isPaused);
        }
    }

    public void ResumeGame()
    {
        isPaused = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;

    }
}
