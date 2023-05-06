using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        PlayerManager.isGameStarted = true;
        PlayerManager.isGameOver = false;
        mainMenuPanel.SetActive(false);
    }

}
