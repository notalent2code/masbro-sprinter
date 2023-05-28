using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Events : MonoBehaviour
{
    public GameObject mainMenuPanel;
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
        mainMenuPanel.SetActive(false);
    }

}
