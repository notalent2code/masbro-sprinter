using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;

    void Start()
    {
        isGameOver = false;
        isGameStarted = false;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);
        }   
    }
}
