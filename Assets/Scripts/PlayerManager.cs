using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;
    public GameObject tapToStartText;
    public static bool isInMainMenu;
    public static bool isGameStarted;
    public static bool isGameOver;
    public static int coins;

    void Start()
    {
        coins = 0;
        isInMainMenu = true;
        isGameStarted = false;
        isGameOver = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameStarted && !isInMainMenu)
        {
            tapToStartText.SetActive(true);
            if (SwipeManager.tap)
            {
                isGameStarted = true;
                tapToStartText.SetActive(false);
            }
        }

        if (isGameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }

    }
}
