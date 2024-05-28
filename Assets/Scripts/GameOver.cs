using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    public void toMainMeniu()
    {
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
