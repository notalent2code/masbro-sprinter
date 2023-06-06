using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject gameOverPanel;
    public GameObject tapToStartText;
    public static bool isInMainMenu;
    public static bool isGameStarted;
    public static bool isGameOver;
    public static int totalScore;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        totalScore = 0;
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

        if (isGameStarted)
        {
            scoreText.gameObject.SetActive(true);
            scoreText.text = "Score: " + totalScore.ToString();
        }
        else
        {
            scoreText.gameObject.SetActive(false);
        }

        if (isGameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
            // Set scoreText position to the middle of the screen
            RectTransform scoreRectTransform = scoreText.GetComponent<RectTransform>();
            scoreRectTransform.anchorMin = new Vector2(0.58f, 0.67f);
            scoreRectTransform.anchorMax = new Vector2(0.58f, 0.67f);
            scoreRectTransform.anchoredPosition = Vector2.zero;
        }
    }
}
