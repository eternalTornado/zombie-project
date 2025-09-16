using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenuScreen;
    public GameObject gameplayScreen;
    public GameObject gameOverScreen;
    public TextMeshProUGUI scoreDisplay;
    public TextMeshProUGUI totalScoreDisplay;

    int totalScore;
    public List<GameObject> allUIScreens = new();

    private void OnEnable()
    {
        ShowMainMenu();
        EventManager.AddScoreToPlayer += AddScoreToPlayer;
        EventManager.GameEnded += OnGame;
    }

    private void OnDisable()
    {
        EventManager.AddScoreToPlayer -= AddScoreToPlayer;
        EventManager.GameEnded -= OnGame;
    }

    public void StartGameClicked()
    {
        ShowGameplayScreen();
        EventManager.GameStarted?.Invoke();
    }

    public void OnRestartGameClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ShowMainMenu()
    {
        DisableAllScreens();
        mainMenuScreen.SetActive(true);
    }

    private void ShowGameplayScreen()
    {
        DisableAllScreens();
        gameplayScreen.SetActive(true);
    }

    private void ShowGameOverScreen()
    {
        DisableAllScreens();
        gameOverScreen.SetActive(true);
        totalScoreDisplay.text = "Total Score: " + totalScore.ToString();
    }

    private void DisableAllScreens()
    {
        foreach (var screen in allUIScreens)
        {
            screen.SetActive(false);
        }
    }

    private void AddScoreToPlayer(int obj)
    {
        totalScore += obj;
        scoreDisplay.text = "Score: " + totalScore.ToString();
    }

    private void OnGame()
    {
        ShowGameOverScreen();
    }
}
