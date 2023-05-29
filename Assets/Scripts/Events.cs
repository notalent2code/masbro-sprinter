using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;

    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartButton()
    {
        PlayerManager.isInMainMenu = false;
        PlayerManager.isGameStarted = false;
        PlayerManager.isGameOver = false;
        mainMenuPanel.SetActive(false);
    }

    public void MainMenuButton()
    {
        PlayerManager.isInMainMenu = true;
        PlayerManager.isGameStarted = false;
        PlayerManager.isGameOver = false;
        gameOverPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        RestartGame();
    }

}
