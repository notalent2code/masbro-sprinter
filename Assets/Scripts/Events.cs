using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;
    public GameObject settingPanel;
    public FunfactPopup funfactPopup;

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
        RestartGame();
    }

    public void FunfactButton()
    {
        funfactPopup.ShowRandomFunfact();
    }

    public void SettingButton()
    {
        settingPanel.SetActive(true);
    }

    public void BackButton()
    {
        settingPanel.SetActive(false);
    }
}
