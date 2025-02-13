using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PuseMenu : MonoBehaviour
{
    public static bool GameOause=false;

    public GameObject pauseMenuUi;
    void Start()
    {
        pauseMenuUi.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameOause)
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
        pauseMenuUi.SetActive(false);
        Time.timeScale = 1f;
        GameOause = false;
    }
    void Pause()
    {
        pauseMenuUi.SetActive(true);
        Time.timeScale = 0f;
        GameOause = true;
    }
    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("main menu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
