using System.Collections.Generic;
using TMPro;
using UnityEngine;

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
        // ShowMainMenu();
        // EventManager.AddScoreToPlayer += OnAddScoreToPlayer;
        // EventManager.GameEnded += OnGameEnded;
    }
}
