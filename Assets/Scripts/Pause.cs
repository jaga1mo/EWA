using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    void Start()
    {
        pauseMenu.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && !PlayerMovement.dialogue)
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        PlayerMovement.dialogue = true;
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        PlayerMovement.dialogue = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    void toMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
