using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{

    public GameObject canvas;

    private bool _isPaused;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            _isPaused = !_isPaused;

            if (_isPaused)
            {
                Time.timeScale = 0;
                canvas.SetActive(true);
            }
            else
            {
                Time.timeScale = 1;
                canvas.SetActive(false);
            }
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Resume()
    {
        Time.timeScale = 1;
        canvas.SetActive(false);
    }
}
